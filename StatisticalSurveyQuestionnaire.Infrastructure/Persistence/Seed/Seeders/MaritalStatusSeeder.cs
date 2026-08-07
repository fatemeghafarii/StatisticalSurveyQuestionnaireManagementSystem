using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class MaritalStatusSeeder
{
    private readonly ApplicationDbContext _context;

    public MaritalStatusSeeder(ApplicationDbContext context) => _context = context;

    public async Task SeedAsync()
    {
        if (await _context.MaritalStatuses.AnyAsync())
            return;

        var items = new List<MaritalStatus>
        {
            new()
            {
                Title = "مجرد",
                Order = 1,
                IsActive = true
            },
            new()
            {
                Title = "متأهل",
                Order = 2,
                IsActive = true
            },
           new()
            {
                Title = "مطلقه",
                Order = 3,
                IsActive = true
            },
           new()
            {
                Title = "بیوه",
                Order = 4,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            SeedEntityHelper.SetAuditFields(item);
        }

        await _context.MaritalStatuses.AddRangeAsync(items);

        await _context.SaveChangesAsync();
    }
}
