using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// What choices are available? 
/// QuestionType:Single Choice |یعنی باید یک گزینه راانتخاب بکند
/// QuestionOption: 1 - Single 2 - Marrie 3 - Divorce 4 - Widowed
/// </summary>
public class QuestionOption : BaseEntity<int>
{
    public int QuestionId { get; set; }
    public string Text { get; set; } = null!;   
    public int Order { get; set; }
    public Question Question { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();    
}
