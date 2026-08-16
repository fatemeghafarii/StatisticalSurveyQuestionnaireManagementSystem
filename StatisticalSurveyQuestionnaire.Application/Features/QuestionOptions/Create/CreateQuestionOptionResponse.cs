namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.Create;

public sealed class CreateQuestionOptionResponse
{
    public int Id { get; init; }

    public int QuestionId { get; init; }

    public string Text { get; init; } = null!;

    public int Order { get; init; }
}
