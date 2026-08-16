using StatisticalSurveyQuestionnaire.Application.Common.Models;

namespace StatisticalSurveyQuestionnaire.Application.Features.QuestionnaireVersions.GetList;

public sealed class GetQuestionnaireVersionsResponse
{
    public PaginatedList<QuestionnaireVersionListItem> Data { get; init; } = null!;
    //public IReadOnlyList<QuestionnaireVersionListItem> Items { get; init; } = new List<QuestionnaireVersionListItem>();

    //public int PageNumber { get; init; }

    //public int PageSize { get; init; }

    //public int TotalCount { get; init; }

    //public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}

public sealed class QuestionnaireVersionListItem
{
    public int Id { get; init; }

    public int QuestionnaireId { get; init; }

    public int VersionNumber { get; init; }

    public string Title { get; init; } = null!;

    public DateTime EffectiveDate { get; init; }

    public int StatusId { get; init; }

    public string StatusCode { get; init; } = null!;

    public bool IsActive { get; init; }
}