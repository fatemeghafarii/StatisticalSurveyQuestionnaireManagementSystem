namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionOptions.GetList;

public sealed class GetQuestionOptionsResponse
{
    public int QuestionId { get; init; }

    public IReadOnlyList<QuestionOptionItem> Items { get; init; } = new List<QuestionOptionItem>();
}
public sealed class QuestionOptionItem
{
    public int Id { get; init; }

    public string Text { get; init; } = null!;

    public int Order { get; init; }
}
