using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// اطلاعات کلی پرسشنامه را نگه می‌دارد
/// </summary>
public class Questionnaire: BaseEntity<int>
{
    /// <summary>
    /// عنوان پرسشنامه
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// توضیحات
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// کد پرسشنامه
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// فعال یا غیرفعال بودن
    /// </summary>
    public bool IsActive { get; set; }
    public ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
    public ICollection<QuestionnaireVersion> QuestionnaireVersions { get; set; } = new List<QuestionnaireVersion>();
}
