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

        var items = new List<Role>
        {
            new()
            {
                Code = "ADMIN",
                Title = "ادمین",
                Order = 1,
                IsActive = true
            },
            new()
            {
                Code = "SYSTEM_MANAGER",
                Title = "مدیر سیستم",
                Order = 2,
                IsActive = true
            },
            new()
            {
                Code = "STATISTICAL_PROJECT_MANAGER",
                Title = "مدیر طرح آماری",
                Order = 3,
                IsActive = true
            },
            new()
            {
                Code = "QUESTIONNAIRE_DESIGNER",
                Title = "طراح پرسشنامه",
                Order = 4,
                IsActive = true
            },
            new()
            {
                Code = "ENUMERATION_SUPERVISOR",
                Title = "سرپرست آمارگیری",
                Order = 5,
                IsActive = true
            },
            new()
            {
                Code = "ENUMERATOR",
                Title = "آمارگیر",
                Order = 6,
                IsActive = true
            },
            new()
            {
                Code = "DATA_REVIEWER",
                Title = "بازبین داده‌ها",
                Order = 7,
                IsActive = true
            },
            new()
            {
                Code = "DATA_REVIEWER",
                Title = "تحلیلگر آماری",
                Order = 8,
                IsActive = true
            },
            new()
            {
                Code = "VIEWER",
                Title = "مشاهده‌گر",
                Order = 9,
                IsActive = true
            },
        };

        foreach (var item in items)
        {
            var existingEntity =
                await _context.Roles
                    .FirstOrDefaultAsync(x => x.Code == item.Code);

            if (existingEntity is null)
            {
                SeedEntityHelper.SetAuditFields(item);

                await _context.Roles.AddAsync(item);

                continue;
            }

            existingEntity.Title = item.Title;
            existingEntity.Order = item.Order;
            existingEntity.IsActive = item.IsActive;
        }

        await _context.SaveChangesAsync();
    }
}
