using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Role : LookupEntity
{
    public ICollection<User> Users { get; set; } = new List<User>();
}
