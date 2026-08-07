using StatisticalSurveyQuestionnaire.Domain.Common;
using StatisticalSurveyQuestionnaire.Domain.ValueObjects;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

/// <summary>
/// خانوار
/// </summary>
public class Household : BaseEntity<int>
{
    public string Code { get; set; } = null!;
    public Address Address { get; set; }
    public ICollection<SurveyResponse> SurveyResponses { get; set; } = new List<SurveyResponse>();
}
