using StatisticalSurveyQuestionnaire.Domain.Common;
using System.Net.NetworkInformation;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Answer: BaseEntity<int>
{
    //TODO: we need to guarantee:
    //The Question being answered belongs to the QuestionnaireVersion associated with the SurveyResponse.
    public int SurveyResponseId { get; set; }
    
    public int QuestionId { get; set; }

    //TODO: about multiple choice
    public string? Value { get; set; } 
    
    public int? QuestionOptionId { get; set; }
    
    public Question Question { get; set; } = null!;
    
    public SurveyResponse SurveyResponse { get; set; } = null!;
    
    public QuestionOption? QuestionOption { get; set; }
}
