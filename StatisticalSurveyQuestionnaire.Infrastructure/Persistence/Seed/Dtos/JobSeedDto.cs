namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Dtos;

public class JobSeedDto
{
    public string Title { get; set; } = null!;
    public string? Code { get; set; }
    public bool IsActive { get; set; }
    public string? ParentCode { get; set; }
}