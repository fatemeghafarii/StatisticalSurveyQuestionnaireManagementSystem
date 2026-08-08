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
        var items = new List<MaritalStatus>
        {
            new()
            {
                Code = "SINGLE",
                Title = "مجرد",
                Order = 1,
                IsActive = true
            },

            new()
            {
                Code = "MARRIED",
                Title = "متأهل",
                Order = 2,
                IsActive = true
            },

            new()
            {
                Code = "DIVORCED",
                Title = "مطلق",
                Order = 3,
                IsActive = true
            },

            new()
            {
                Code = "WIDOWED",
                Title = "بیوه",
                Order = 4,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            var existingEntity =
                await _context.MaritalStatuses
                    .FirstOrDefaultAsync(x => x.Code == item.Code);

            if (existingEntity is null)
            {
                SeedEntityHelper.SetAuditFields(item);

                await _context.MaritalStatuses
                    .AddAsync(item);

                continue;
            }

            existingEntity.Title = item.Title;
            existingEntity.Order = item.Order;
            existingEntity.IsActive = item.IsActive;
        }

        await _context.SaveChangesAsync();
    }
}
