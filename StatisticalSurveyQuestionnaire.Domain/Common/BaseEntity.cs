namespace StatisticalSurveyQuestionnaire.Domain.Common;
public abstract class BaseEntity<TKey> where TKey : struct
{
    public TKey Id { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
    public string CreatedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public bool IsDeleted { get; set; }
}
