using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;
using StatisticalSurveyQuestionnaire.Domain.Common.Constants;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Create;

public sealed class CreateQuestionOptionCommandHandler
    : IRequestHandler<
        CreateQuestionOptionCommand,
        Result<CreateQuestionOptionResponse>>
{
    private readonly IApplicationDbContext _context;

    public CreateQuestionOptionCommandHandler(IApplicationDbContext context) =>
        _context = context;

    public async Task<Result<CreateQuestionOptionResponse>> Handle(CreateQuestionOptionCommand request, CancellationToken cancellationToken)
    {
        var question =
            await _context.Questions
                .AsNoTracking()
                .Include(x => x.QuestionnaireVersion)
                .ThenInclude(x => x.Status)
                .Include(x => x.QuestionType)
                .SingleOrDefaultAsync(x =>
                    x.Id == request.QuestionId,
                    cancellationToken);

        if (question is null)
        {
            return Result<CreateQuestionOptionResponse>
                .Failure(
                "سوال مورد نظر پیدا نشد.");
        }

        if (question.QuestionnaireVersion.Status.Code 
            != QuestionnaireVersionStatusCodes.Draft)
        {
            return Result<CreateQuestionOptionResponse>
                .Failure(
                "فقط برای سوالات نسخه پیش‌ نویس می‌توان گزینه اضافه کرد.");
        }

        var supportsOptions =
            question.QuestionType.Code == QuestionTypeCodes.SingleChoice ||
            question.QuestionType.Code == QuestionTypeCodes.MultipleChoice;

        if (!supportsOptions)
        {
            return Result<CreateQuestionOptionResponse>
                .Failure(
                    "فقط برای سوالات تک انتخابی و چند انتخابی می‌توان گزینه تعریف کرد.");
        }

        var lastOrder =
            await _context.QuestionOptions
                .Where(x =>
                    x.QuestionId ==
                    request.QuestionId)
                .MaxAsync(
                    x => (int?)x.Order,
                    cancellationToken)
                ?? 0;

        var option = new QuestionOption
        {
            QuestionId = request.QuestionId,
            Text = request.Text,
            Order = lastOrder + 1
        };

        await _context.QuestionOptions
            .AddAsync(
                option,
                cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CreateQuestionOptionResponse>
            .Success(
                new CreateQuestionOptionResponse
                {
                    Id = option.Id,
                   
                    QuestionId = option.QuestionId,
                    
                    Text = option.Text,
                    
                    Order = option.Order
                });
    }
}
