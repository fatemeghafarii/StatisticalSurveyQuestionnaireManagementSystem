namespace StatisticalSurveyQuestionnaire.Domain.Common;
public abstract class BaseEntity<TKey> where TKey : struct
{
    public TKey Id { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; } = null!;
    
    public DateTime? ModifiedAt{ get; set; }
    
    public string? ModifiedBy { get; set; }
    
    public bool IsDeleted { get; set; }
}
