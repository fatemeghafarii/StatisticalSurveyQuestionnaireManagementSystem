using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class RoleSeeder
{
    private readonly ApplicationDbContext _context;

    public RoleSeeder(ApplicationDbContext context) => _context = context;
    
    public async Task SeedAsync()
    {
        if (await _context.Roles.AnyAsync())
            return;

        var items = new List<Role>
        {
            new()
            {
                Title = "ادمین",
                Order = 1,
                IsActive = true
            },
            new()
            {
                Title = "مدیر سیستم",
                Order = 2,
                IsActive = true
            },
            new()
            {
                Title = "مدیر طرح آماری",
                Order = 3,
                IsActive = true
            },
            new()
            {
                Title = "طراح پرسشنامه",
                Order = 4,
                IsActive = true
            },
            new()
            {
                Title = "سرپرست آمارگیری",
                Order = 5,
                IsActive = true
            },
            new()
            {
                Title = "آمارگیر",
                Order = 6,
                IsActive = true
            },
            new()
            {
                Title = "بازبین داده‌ها",
                Order = 7,
                IsActive = true
            },
            new()
            {
                Title = "تحلیلگر آماری",
                Order = 8,
                IsActive = true
            },
            new()
            {
                Title = "مشاهده‌گر",
                Order = 9,
                IsActive = true
            },
        };

        foreach (var item in items)
        {
            SeedEntityHelper.SetAuditFields(item);
        }

        await _context.Roles.AddRangeAsync(items);

        await _context.SaveChangesAsync();
    }
}
