using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class SurveyResponseStatusTypeSeeder
{
    private readonly ApplicationDbContext _context;

    public SurveyResponseStatusTypeSeeder(ApplicationDbContext context) => _context = context;

    public async Task SeedAsync()
    {

        var items = new List<SurveyResponseStatusType>
        {
            new()
            {
                Code = "NOT_STARTED",
                Title = "شروع نشده",
                Order = 1,
                IsActive = true
            },
            new()
            {
                Code = "IN_PROGRESS",
                Title = "در حال انجام",
                Order = 2,
                IsActive = true
            },
            new()
            {
                Code = "COMPLETED",
                Title = "تکمیل شده",
                Order = 3,
                IsActive = true
            },
            new()
            {
                Code = "CANCELED",
                Title = "لغو شده",
                Order = 4,
                IsActive = true
            },
            new()
            {
                Code = "REJECTED",
                Title = "رد شده",
                Order = 5,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            var existingEntity =
                await _context.SurveyResponseStatusTypes
                    .FirstOrDefaultAsync(x => x.Code == item.Code);

            if (existingEntity is null)
            {
                SeedEntityHelper.SetAuditFields(item);

                await _context.SurveyResponseStatusTypes
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
