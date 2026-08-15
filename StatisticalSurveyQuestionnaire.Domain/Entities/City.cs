using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class City : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    
    public int ProvinceId { get; set; }
    
    public bool IsActive { get; set; }
    
    public Province Province { get; set; } = null!; 

}
