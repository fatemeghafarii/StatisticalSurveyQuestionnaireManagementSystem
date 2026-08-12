using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Question: BaseEntity<int>
{
    public int QuestionnaireVersionId { get; set; }
    public string Text { get; set; } = null!;
    public int QuestionTypeId { get; set; }
    // برای تعیین ترتیب نمایش سؤال‌ها در پرسشنامه
    public int Order { get; set; }
    public QuestionnaireVersion QuestionnaireVersion { get; set; } = null!;
    public QuestionType QuestionType { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    public ICollection<QuestionOption> QuestionOptions { get; set; } = new List<QuestionOption>();
}
