using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetList;

public sealed class GetQuestionnairesResponse
{
    public PaginatedList<QuestionnaireItem> Data { get; init; } = null!;
}

public sealed class QuestionnaireItem
{
    public int Id { get; init; }

    public string Title { get; init; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; init; }

    public DateTime CreatedAt { get; init; }
}
