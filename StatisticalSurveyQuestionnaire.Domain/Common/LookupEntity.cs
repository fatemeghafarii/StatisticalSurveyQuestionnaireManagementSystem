namespace StatisticalSurveyQuestionnaire.Domain.Common;

public abstract class LookupEntity : BaseEntity<int>
{
    public string Title { get; set; } = null!;
    public int Order { get; set; }
    public bool IsActive { get; set; }
}