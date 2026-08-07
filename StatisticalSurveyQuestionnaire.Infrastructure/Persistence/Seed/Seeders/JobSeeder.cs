using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Dtos;
using StatisticalSurveyQuestionnaire.Infrastructure.Services;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

public class JobSeeder
{
    private readonly ApplicationDbContext _context;
    private readonly IJsonFileReader _jsonFileReader;


    public JobSeeder(
        ApplicationDbContext context,
        IJsonFileReader jsonFileReader)
    {
        _context = context;
        _jsonFileReader = jsonFileReader;
    }


    public async Task SeedAsync()
    {
        if (await _context.Jobs.AnyAsync())
            return;


        var items = await _jsonFileReader
            .ReadAsync<List<JobSeedDto>>("Jobs.json");


        var jobs = new List<Job>();


        foreach (var item in items!)
        {
            var job = new Job
            {
                Title = item.Title,
                Code = item.Code,
                IsActive = item.IsActive
            };


            SeedEntityHelper.SetAuditFields(job);


            jobs.Add(job);
        }


        await _context.Jobs.AddRangeAsync(jobs);

        await _context.SaveChangesAsync();



        // Set parent relationships

        foreach (var item in items)
        {
            if (item.ParentCode == null)
                continue;


            var job = await _context.Jobs
                .FirstAsync(x => x.Code == item.Code);


            var parentJob = await _context.Jobs
                .FirstAsync(x => x.Code == item.ParentCode);


            job.ParentJobId = parentJob.Id;
        }


        await _context.SaveChangesAsync();
    }
}
