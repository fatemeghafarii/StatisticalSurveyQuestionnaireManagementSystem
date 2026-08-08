using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class QuestionnaireVersionStatusTypeSeeder
{
    private readonly ApplicationDbContext _context;

    public QuestionnaireVersionStatusTypeSeeder(ApplicationDbContext context) => _context = context;

    public async Task SeedAsync()
    {
        var items = new List<QuestionnaireVersionStatusType>
        {
            new()
            {
                Code = "DRAFT",
                Title = "پیش ‌نویس",
                Order = 1,
                IsActive = true
            },

            new()
            {
                Code = "PUBLISHED",
                Title = "منتشر شده",
                Order = 2,
                IsActive = true
            },

            new()
            {
                Code = "CLOSED",
                Title = "بسته شده",
                Order = 3,
                IsActive = true
            },

            new()
            {
                Code = "ARCHIVED",
                Title = "بایگانی شده",
                Order = 4,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            var existingEntity =
                await _context.QuestionnaireVersionStatusTypes
                    .FirstOrDefaultAsync(x => x.Code == item.Code);

            if (existingEntity is null)
            {
                SeedEntityHelper.SetAuditFields(item);

                await _context.QuestionnaireVersionStatusTypes
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
