using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Domain.ValueObjects;
public class Address
{
    public int CityId { get; set; }
    public string Street { get; set; }
    public string Alley { get; set; }
    public string HouseNumber { get; set; }
    public string PostalCode { get; set; }
    public City City { get; set; } = null!;
}
