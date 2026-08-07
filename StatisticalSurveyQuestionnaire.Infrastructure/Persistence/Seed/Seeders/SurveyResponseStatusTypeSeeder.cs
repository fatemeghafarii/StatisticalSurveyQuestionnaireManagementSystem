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
        if (await _context.SurveyResponseStatusTypes.AnyAsync())
            return;

        var items = new List<SurveyResponseStatusType>
        {
            new()
            {
                Title = "شروع نشده",
                Order = 1,
                IsActive = true
            },
            new()
            {
                Title = "در حال انجام",
                Order = 2,
                IsActive = true
            },
            new()
            {
                Title = "تکمیل شده",
                Order = 3,
                IsActive = true
            },
            new()
            {
                Title = "لغو شده",
                Order = 4,
                IsActive = true
            },
            new()
            {
                Title = "رد شده",
                Order = 5,
                IsActive = true
            }
        };

        foreach (var item in items)
        {
            SeedEntityHelper.SetAuditFields(item);
        }

        await _context.SurveyResponseStatusTypes.AddRangeAsync(items);

        await _context.SaveChangesAsync();
    }
}
