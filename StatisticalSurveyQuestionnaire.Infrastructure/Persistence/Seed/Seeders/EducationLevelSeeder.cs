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
        if (await _context.EducationLevels.AnyAsync())
            return;

        var items = new List<EducationLevel>
        {
            new()
            {
                Title = "بی‌سواد",
                Order = 1,
                IsActive = true
            },
            new()
            {
                Title = "سیکل",
                Order = 2,
                IsActive = true
            },
            new()
            {
                Title = "دیپلم",
                Order = 3,
                IsActive = true
            },
            new()
            {
                Title = "کاردانی",
                Order = 4,
                IsActive = true
            },
            new()
            {
                Title = "کارشناسی",
                Order = 5,
                IsActive = true
            },
            new()
            {
                Title = "کارشناسی ارشد",
                Order = 6,
                IsActive = true
            },
            new()
            {
                Title = "دکتری",
                Order = 7,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            SeedEntityHelper.SetAuditFields(item);
        }

        await _context.EducationLevels.AddRangeAsync(items);

        await _context.SaveChangesAsync();
    }
}
