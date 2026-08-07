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
        if (await _context.QuestionTypes.AnyAsync())
            return;

        var items = new List<QuestionType>
        {
            new()
            {
                Title = "Text",
                Code = "TEXT",
            },
            new()
            {
                Title = "Number",
                Code = "NUMBER",
            },
            new()
            {
                Title = "Date",
                Code = "DATE",
            },
            new()
            {
                Title = "Single Choice",
                Code = "SINGLE_CHOICE",

            },
            new()
            {
                Title = "Multiple Choice",
                Code = "MULTIPLE_CHOICE"
            },
            new()
            {
                Title = "Boolean",
                Code = "BOOLEAN"
            }
        };

        foreach (var item in items)
        {
            SeedEntityHelper.SetAuditFields(item);
        }

        await _context.QuestionTypes.AddRangeAsync(items);

        await _context.SaveChangesAsync();
    }
}
