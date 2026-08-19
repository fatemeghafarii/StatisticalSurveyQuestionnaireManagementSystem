namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.Close;

public sealed class CloseQuestionnaireVersionResponse
{
    public int Id { get; init; }
    public int QuestionnaireId { get; init; }
    public int VersionNumber { get; init; }
    public string Title { get; init; } = null!;
    public DateTime EffectiveDate { get; init; }
    public int StatusId { get; init; }
    public string StatusCode { get; init; } = null!;
    public string StatusTitle { get; init; } = null!;
    public bool IsActive { get; init; }
}
