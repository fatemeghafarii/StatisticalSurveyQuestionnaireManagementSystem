using StatisticalSurveyQuestionnaire.Domain.Common;

namespace StatisticalSurveyQuestionnaire.Domain.Entities;

public class Job : LookupEntity
{
    public string? Code { get; set; }
    
    public int? ParentJobId { get; set; }
    
    public Job? ParentJob { get; set; }
    
    public ICollection<Job> ChildJobs { get; set; } = new List<Job>();
}