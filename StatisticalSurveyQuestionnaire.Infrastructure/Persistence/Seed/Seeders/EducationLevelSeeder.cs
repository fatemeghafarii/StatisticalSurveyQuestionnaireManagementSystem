using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class EducationLevelSeeder
{
    private readonly ApplicationDbContext _context;

    public EducationLevelSeeder(ApplicationDbContext context) => _context = context;

    public async Task SeedAsync()
    {
        var items = new List<EducationLevel>
        {
            new()
            {
                Code = "ILLITERATE",
                Title = "بی‌سواد",
                Order = 1,
                IsActive = true
            },

            new()
            {
                Code = "CYCLE",
                Title = "سیکل",
                Order = 2,
                IsActive = true
            },

            new()
            {
                Code = "DIPLOMA",
                Title = "دیپلم",
                Order = 3,
                IsActive = true
            },

            new()
            {
                Code = "ASSOCIATE",
                Title = "کاردانی",
                Order = 4,
                IsActive = true
            },

            new()
            {
                Code = "BACHELOR",
                Title = "کارشناسی",
                Order = 5,
                IsActive = true
            },

            new()
            {
                Code = "MASTER",
                Title = "کارشناسی ارشد",
                Order = 6,
                IsActive = true
            },

            new()
            {
                Code = "PHD",
                Title = "دکتری",
                Order = 7,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            var existingEntity =
                await _context.EducationLevels
                    .FirstOrDefaultAsync(x => x.Code == item.Code);

            if (existingEntity is null)
            {
                SeedEntityHelper.SetAuditFields(item);

                await _context.EducationLevels.AddAsync(item);

                continue;
            }

            existingEntity.Title = item.Title;
            existingEntity.Order = item.Order;
            existingEntity.IsActive = item.IsActive;
        }

        await _context.SaveChangesAsync();
    }
}
