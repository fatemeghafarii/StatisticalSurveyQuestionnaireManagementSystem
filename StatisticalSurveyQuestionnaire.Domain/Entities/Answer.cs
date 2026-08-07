using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Answer: BaseEntity<int>
{
    public int SurveyResponseId { get; set; }
    public int QuestionId { get; set; }
    public string? Value { get; set; } 
    public int? QuestionOptionId { get; set; }
    public Question Question { get; set; } = null!;
    public SurveyResponse SurveyResponse { get; set; } = null!;
    public QuestionOption? QuestionOption { get; set; }
}
