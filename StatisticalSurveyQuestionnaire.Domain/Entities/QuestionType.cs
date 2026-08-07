using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// defindes how to answer for example Text question, Number question...
/// </summary>
public class QuestionType: BaseEntity<int>
{
    public string Title { get; set; } = null!;  
    public string Code { get; set; } = null!;   
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
