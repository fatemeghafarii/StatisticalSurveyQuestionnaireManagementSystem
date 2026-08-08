using MediatR;
using StatisticalSurveyQuestionnaire.Application.Common.Enums;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Application.Common.Results;
using StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Create;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.Create;
public class CreateQuestionnaireCommand
(
    string Title,
    string? Description,
    bool IsActive

) : IRequest<Result<CreateQuestionnaireResponse>>;
public class CreateQuestionnaireCommandHandler //Result<CreateQuestionnaireCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly ICodeGenerator _codeGenerator;

    public CreateQuestionnaireCommandHandler(IApplicationDbContext context, ICodeGenerator codeGenerator)
    {
        _context = context;
        _codeGenerator = codeGenerator;
    }

    //var questionnaire = new Questionnaire
    //{
    //    Title = request.Title,
    //    Description = request.Description,
    //    Code = _codeGenerator.Generate(CodePrefix.Questionnaire),
    //    IsActive = request.IsActive
    //};
}
public class CreateQuestionnaireValidator
{
}
public sealed class CreateQuestionnaireResponse
{
    public int Id { get; init; }
    public string Title { get; init; } = null!;
}