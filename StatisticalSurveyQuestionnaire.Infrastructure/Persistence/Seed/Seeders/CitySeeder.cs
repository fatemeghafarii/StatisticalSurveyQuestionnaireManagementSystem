using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Dtos;
using StatisticalSurveyQuestionnaire.Infrastructure.Services;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;
public class CitySeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IJsonFileReader _jsonFileReader;

    public CitySeeder(
        ApplicationDbContext context,
        IJsonFileReader jsonFileReader)
    {
        _context = context;
        _jsonFileReader = jsonFileReader;
    }

    public async Task SeedAsync()
    {
        if (await _context.Cities.AnyAsync())
            return;

        var items = await _jsonFileReader
            .ReadAsync<List<CitySeedDto>>("Cities.json");
        
        var cities = new List<City>();

        foreach (var item in items!)
        {
            var province = await _context.Provinces
                .FirstAsync(x => x.Name == item.ProvinceName);

            foreach (var cityName in item.Cities)
            {
                var city = new City
                {
                    Name = cityName,
                    ProvinceId = province.Id
                };


                SeedEntityHelper.SetAuditFields(city);

                cities.Add(city);
            }
        }

        await _context.Cities.AddRangeAsync(cities);

        await _context.SaveChangesAsync();
    }
}
