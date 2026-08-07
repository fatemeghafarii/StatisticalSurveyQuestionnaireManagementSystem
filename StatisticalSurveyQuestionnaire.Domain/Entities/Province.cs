using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Province : BaseEntity<int>
{
    public string Name { get; set; } = null!;
    public int Order { get; set; }
    public bool IsActive { get; set; }
    public ICollection<City> Cities { get; set; } = new List<City>();
}
