namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Dtos;
public class CitySeedDto
{
    public string ProvinceName { get; set; } = null!;
    public List<string> Cities { get; set; } = new();
}
