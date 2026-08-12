using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// اطلاعات کلی پرسشنامه را نگه می‌دارد
/// </summary>
public class Questionnaire: BaseEntity<int>
{
    // عنوان پرسشنامه
    public string Title { get; set; } = null!;
    // توضیحات
    public string? Description { get; set; }
    // کد پرسشنامه
    public string Code { get; set; } = null!;
    // فعال یا غیرفعال بودن
    public bool IsActive { get; set; }
    public ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
    public ICollection<QuestionnaireVersion> QuestionnaireVersions { get; set; } = new List<QuestionnaireVersion>();
}
