namespace StatisticalSurveyQuestionnaire.Application.Features.Questionnaires.GetById;

public sealed class GetQuestionnaireByIdResponse
{
    public int Id { get; init; }

    public string Title { get; init; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActive { get; init; }

    public DateTime CreatedAt { get; init; }

    public IReadOnlyList<QuestionnaireVersionItem> Versions { get; init; } = new List<QuestionnaireVersionItem>();
}

public sealed class QuestionnaireVersionItem
{
    public int Id { get; init; }

    public int VersionNumber { get; set; }

    public string Title { get; set; } = null!;

    public DateTime EffectiveDate { get; init; }

    public int StatusId { get; init; }

    public string StatusCode { get; init; } = null!;

    public string StatusTitle { get; init; } = null!;

    public bool IsActive { get; init; }
}