using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Answer : BaseEntity<int>
{
    //TODO: we need to guarantee:
    //The Question being answered belongs to the QuestionnaireVersion associated with the SurveyResponse.
    public int SurveyResponseId { get; set; }

    public int QuestionId { get; set; }

    public string? Value { get; set; }

    public Question Question { get; set; } = null!;

    public SurveyResponse SurveyResponse { get; set; } = null!;

    public ICollection<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();
}
