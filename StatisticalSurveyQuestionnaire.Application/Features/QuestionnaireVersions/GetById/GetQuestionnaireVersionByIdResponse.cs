namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetById;

public sealed class GetQuestionnaireVersionByIdResponse
{
    public int Id { get; init; }
    public int QuestionnaireId { get; init; }
    public int VersionNumber { get; init; }
    public string Title { get; init; } = null!;
    public DateTime EffectiveDate { get; init; }
    public int StatusId { get; init; }
    public string StatusTitle { get; init; } = null!;
    public bool IsActive { get; init; }
}
