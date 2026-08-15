using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class SurveyResponse : BaseEntity<int>
{
    public int HouseholdId { get; set; }
    
    public int QuestionnaireVersionId { get; set; }
    
    public int SurveyPeriodId { get; set; }
    
    public int StatusId { get; set; }
    
    public DateTime? StartedDate { get; set; }
    
    public DateTime? CompletedDate { get; set; }
    
    public Household Household { get; set; } = null!;
    
    public QuestionnaireVersion QuestionnaireVersion { get; set; } = null!;
    
    public SurveyPeriod SurveyPeriod { get; set; } = null!;
    
    public SurveyResponseStatusType Status { get; set; } = null!;
    
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
