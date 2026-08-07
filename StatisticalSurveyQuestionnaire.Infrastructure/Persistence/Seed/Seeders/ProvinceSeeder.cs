using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Dtos;
using StatisticalSurveyQuestionnaire.Infrastructure.Services;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class ProvinceSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IJsonFileReader _jsonFileReader;

    public ProvinceSeeder(
        ApplicationDbContext context,
        IJsonFileReader jsonFileReader)
    {
        _context = context;
        _jsonFileReader = jsonFileReader;
    }

    public async Task SeedAsync()
    {
        if (await _context.Provinces.AnyAsync())
            return;

        var items = await _jsonFileReader
            .ReadAsync<List<ProvinceSeedDto>>("Provinces.json");

        var provinces = new List<Province>();

        foreach (var item in items!)
        {
            var province = new Province
            {
                Name = item.Name,
                Order = item.Order
            };

            SeedEntityHelper.SetAuditFields(province);

            provinces.Add(province);
        }

        await _context.Provinces.AddRangeAsync(provinces);

        await _context.SaveChangesAsync();
    }
}
