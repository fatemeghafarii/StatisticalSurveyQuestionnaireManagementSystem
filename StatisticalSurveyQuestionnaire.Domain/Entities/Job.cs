using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Job : LookupEntity
{
    public int? ParentJobId { get; set; }
    
    public Job? ParentJob { get; set; }
    
    public ICollection<Job> ChildJobs { get; set; } = new List<Job>();

    public ICollection<Person> Persons { get; set; } = new List<Person>();
}