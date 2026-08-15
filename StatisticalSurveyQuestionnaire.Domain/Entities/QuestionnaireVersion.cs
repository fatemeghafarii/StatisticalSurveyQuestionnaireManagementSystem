using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// Household Income Survey
/// Version 1 (2025)
///Questions:
///        - Age
///        - Gender
///        - Income
///
///Version 2 (2026)
///    Questions:
///        - Age
///        - Gender
///        - Income
///        - Employment Status
/// </summary>
public class QuestionnaireVersion : BaseEntity<int>
{
    public int QuestionnaireId { get; set; }
    
    public int VersionNumber { get; set; }
    
    public string Title { get; set; } = null!;

    /// <summary>
    /// When this version becomes available
    /// CreatedDate => When the version was created in the system
    /// EffectiveDate => When the version officially becomes applicable
    /// SurveyPeriod => What statistical period does this survey cover?
    /// </summary>
    public DateTime EffectiveDate { get; set; }
    
    public int StatusId { get; set; }
    
    public bool IsActive { get; set; }
    
    public Questionnaire Questionnaire { get; set; } = null!;   
    
    public QuestionnaireVersionStatusType Status { get; set; } = null!;   
    
    public ICollection<Question> Questions { get; set; } = new List<Question>();
    
    public ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}