using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.Questions.GetList;

public sealed class GetQuestionsResponse
{
    public PaginatedList<QuestionItem> Data { get; init; } = null!;
    //public IReadOnlyList<QuestionListItem> Items { get; init; } = new List<QuestionListItem>();

    //public int PageNumber { get; init; }

    //public int PageSize { get; init; }

    //public int TotalCount { get; init; }

    //public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}

public sealed class QuestionItem
{
    public int Id { get; init; }

    public int QuestionnaireVersionId { get; init; }

    public string Text { get; init; } = null!;

    public int QuestionTypeId { get; init; }

    public string QuestionTypeTitle { get; init; } = null!;

    public int Order { get; init; }
}