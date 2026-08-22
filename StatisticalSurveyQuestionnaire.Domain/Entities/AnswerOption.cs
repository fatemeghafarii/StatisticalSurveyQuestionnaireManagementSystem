using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class AnswerOption : BaseEntity<int>
{
    public int AnswerId { get; set; }

    public int QuestionOptionId { get; set; }

    public Answer Answer { get; set; } = null!;

    public QuestionOption QuestionOption { get; set; } = null!;
}