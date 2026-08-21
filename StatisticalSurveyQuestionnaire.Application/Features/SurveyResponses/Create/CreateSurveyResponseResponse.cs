namespace StatisticalSurveyQuestionnaire.Application.Features.SurveyResponses.Create;

public sealed class CreateSurveyResponseResponse
{
    public int Id { get; init; }

    public int HouseholdId { get; init; }
    
    public string HouseholdCode { get; init; } = null!;
    
    public int QuestionnaireVersionId { get; init; }
    
    public int VersionNumber { get; init; }
    
    public string VersionStatusCode { get; init; } = null!;

    public string VersionStatusTitle { get; init; } = null!;

    public int SurveyPeriodId { get; init; }

    public int ResponseStatusId { get; init; }
    
    public string ResponseStatusCode { get; init; } = null!;

    public string ResponseStatusTitle { get; init; } = null!;

    public DateTime? StartedDate { get; init; }
    
    public DateTime? CompletedDate { get; init; }
}
