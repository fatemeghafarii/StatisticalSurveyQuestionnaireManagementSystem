namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionTypes.GetList;

public sealed class GetQuestionTypesResponse
{
    public IReadOnlyList<QuestionTypeItem> Items { get; init; } = new List<QuestionTypeItem>();
}
public sealed class QuestionTypeItem
{
    public int Id { get; init; }

    public string Title { get; init; } = null!;

    public int Order { get; init; }

    public bool IsActive { get; init; }
}