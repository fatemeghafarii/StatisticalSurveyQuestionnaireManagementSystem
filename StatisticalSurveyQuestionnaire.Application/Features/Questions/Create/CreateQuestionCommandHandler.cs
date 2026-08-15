using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Constants;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.Create;

public sealed class CreateQuestionCommandHandler
    : IRequestHandler<
        CreateQuestionCommand,
        Result<CreateQuestionResponse>>
{
    private readonly IApplicationDbContext _context;
    public CreateQuestionCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Result<CreateQuestionResponse>> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        var version =
            await _context.QuestionnaireVersions
                .Include(x => x.Status)
                .SingleOrDefaultAsync(
                    x => x.Id == request.QuestionnaireVersionId,
                    cancellationToken);

        if (version is null)
        {
            return Result<CreateQuestionResponse>
                 .Failure(
                     "نسخه مورد نظر پیدا نشد.");
        }

        if (version.Status.Code != QuestionnaireVersionStatusCodes.Draft)
        {
            return Result<CreateQuestionResponse>
                 .Failure(
                     "فقط در نسخه پیش‌ نویس امکان اضافه کردن سوال وجود دارد.");
        }

        var questionTypeExists =
            await _context.QuestionTypes
                .AnyAsync(
                    x => x.Id == request.QuestionTypeId,
                    cancellationToken);

        if (!questionTypeExists)
        {
            return Result<CreateQuestionResponse>
                 .Failure(
                     "نوع سوال مورد نظر پیدا نشد.");
        }

        var lastOrder =
            await _context.Questions
                .Where(x =>
                    x.QuestionnaireVersionId ==
                    request.QuestionnaireVersionId)
                .MaxAsync(
                    x => (int?)x.Order,
                    cancellationToken)
                ?? 0;

        var question = new Question
        {
            QuestionnaireVersionId = request.QuestionTypeId,
            Text = request.Text,
            QuestionTypeId = request.QuestionTypeId,
            Order = lastOrder + 1
        };

        await _context.Questions
            .AddAsync(
                question,
                cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CreateQuestionResponse>
            .Success(
            new CreateQuestionResponse
            {
                Id = question.Id,
                QuestionnaireVersionId = question.QuestionnaireVersionId,
                Text = question.Text,
                QuestionTypeId = question.QuestionTypeId,
                Order = question.Order

            });
    }
}
