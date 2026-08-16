using StatisticalSurveyQuestionnaire.Application.Features.Questions.GetList;

namespace StatisticalSurveyQuestionnaire.Application.Common.Models;
public sealed class PaginatedList<T>
{
    public IReadOnlyList<T> Items { get; init; } = new List<T>();

    public int PageNumber { get; init; }

    public int PageSize { get; init; }

    public int TotalCount { get; init; }

    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}
