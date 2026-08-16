namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Update;

public sealed class UpdateQuestionOptionResponse
{
    public int Id { get; init; }

    public int QuestionId { get; init; }

    public string Text { get; init; } = null!;

    public int Order { get; init; }
}
