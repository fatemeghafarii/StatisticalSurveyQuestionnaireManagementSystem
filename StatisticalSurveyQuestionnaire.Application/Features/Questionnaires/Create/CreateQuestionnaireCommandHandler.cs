using MediatR;
using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Enums;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Models;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Create;

public sealed class CreateQuestionnaireCommandHandler
    : IRequestHandler<CreateQuestionnaireCommand,
        Result<CreateQuestionnaireResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly ICodeGenerator _codeGenerator;

    public CreateQuestionnaireCommandHandler(IApplicationDbContext context, ICodeGenerator codeGenerator)
    {
        _context = context;
        _codeGenerator = codeGenerator;
    }

    public async Task<Result<CreateQuestionnaireResponse>> Handle(CreateQuestionnaireCommand request, CancellationToken cancellationToken)
    {
        var questionnaireExists =
            await _context.Questionnaires
                .AnyAsync(
                    x => x.Title == request.Title,
                    cancellationToken);

        if (!questionnaireExists) 
        {
            return Result<CreateQuestionnaireResponse>
                 .Failure(
                     "پرسشنامه مورد نظر پیدا نشد.");
        }

        var questionnaire = new Questionnaire
        {
            Title = request.Title,
            Description = request.Description,
            Code = _codeGenerator.Generate(CodePrefix.Questionnaire),
            IsActive = false
        };

        await _context.Questionnaires
            .AddAsync(questionnaire, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<CreateQuestionnaireResponse>
            .Success(
                new CreateQuestionnaireResponse
                {
                    Id = questionnaire.Id,
                    Title = questionnaire.Title,
                    Code = questionnaire.Code,
                    IsActive = questionnaire.IsActive
                });
    }
}
