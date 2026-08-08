using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class QuestionTypeSeeder
{
    private readonly ApplicationDbContext _context;

    public QuestionTypeSeeder(ApplicationDbContext context) => _context = context;

    public async Task SeedAsync()
    {
        var items = new List<QuestionType>
        {
            new()
            {
                Code = "TEXT",
                Title = "متنی",
                Order = 1,
                IsActive = true
            },

            new()
            {
                Code = "NUMBER",
                Title = "عددی",
                Order = 2,
                IsActive = true
            },

            new()
            {
                Code = "SINGLE_CHOICE",
                Title = "تک انتخابی",
                Order = 3,
                IsActive = true
            },

            new()
            {
                Code = "MULTIPLE_CHOICE",
                Title = "چند انتخابی",
                Order = 4,
                IsActive = true
            },

            new()
            {
                Code = "BOOLEAN",
                Title = "بله / خیر",
                Order = 5,
                IsActive = true
            },

            new()
            {
                Code = "DATE",
                Title = "تاریخ",
                Order = 6,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            var existingEntity =
                await _context.QuestionTypes
                    .FirstOrDefaultAsync(x => x.Code == item.Code);

            if (existingEntity is null)
            {
                SeedEntityHelper.SetAuditFields(item);

                await _context.QuestionTypes.AddAsync(item);

                continue;
            }

            existingEntity.Title = item.Title;
            existingEntity.Order = item.Order;
            existingEntity.IsActive = item.IsActive;
        }

        await _context.SaveChangesAsync();
    }
}
