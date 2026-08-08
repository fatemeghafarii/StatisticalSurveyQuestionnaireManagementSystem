using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// defindes how to answer for example Text question, Number question...
/// </summary>
public class QuestionType: LookupEntity
{
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}
