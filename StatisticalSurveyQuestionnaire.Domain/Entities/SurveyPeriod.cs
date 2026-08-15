using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// Questionnaire Version 
/// </summary>
public class SurveyPeriod : BaseEntity<int>
{
    public string Title { get; set; } = null!;
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public bool IsActive { get; set; }
    
    public ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}