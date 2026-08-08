using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed;

public class DbInitializer
{
    private readonly ApplicationDbContext _context;

    private readonly ProvinceSeeder _provinceSeeder;
    private readonly CitySeeder _citySeeder;

    private readonly EducationLevelSeeder _educationLevelSeeder;
    private readonly MaritalStatusSeeder _maritalStatusSeeder;
    private readonly QuestionTypeSeeder _questionTypeSeeder;
    private readonly SurveyResponseStatusTypeSeeder _surveyResponseStatusTypeSeeder;
    private readonly QuestionnaireVersionStatusTypeSeeder _questionnaireVersionStatusTypeSeeder;
    private readonly RoleSeeder _roleSeeder;

    private readonly JobSeeder _jobSeeder;

    public DbInitializer(
        ApplicationDbContext context,

        ProvinceSeeder provinceSeeder,
        CitySeeder citySeeder,

        EducationLevelSeeder educationLevelSeeder,
        MaritalStatusSeeder maritalStatusSeeder,
        QuestionTypeSeeder questionTypeSeeder,
        SurveyResponseStatusTypeSeeder surveyResponseStatusTypeSeeder,
        QuestionnaireVersionStatusTypeSeeder questionnaireVersionStatusTypeSeeder,
        RoleSeeder roleSeeder,

        JobSeeder jobSeeder)
    {
        _context = context;

        _provinceSeeder = provinceSeeder;
        _citySeeder = citySeeder;

        _educationLevelSeeder = educationLevelSeeder;
        _maritalStatusSeeder = maritalStatusSeeder;
        _questionTypeSeeder = questionTypeSeeder;
        _surveyResponseStatusTypeSeeder = surveyResponseStatusTypeSeeder;
        _questionnaireVersionStatusTypeSeeder = questionnaireVersionStatusTypeSeeder;
        _roleSeeder = roleSeeder;

        _jobSeeder = jobSeeder;
    }

    public async Task InitializeAsync()
    {
        await _context.Database.MigrateAsync();


        await _provinceSeeder.SeedAsync();

        await _citySeeder.SeedAsync();


        await _educationLevelSeeder.SeedAsync();

        await _maritalStatusSeeder.SeedAsync();

        await _questionTypeSeeder.SeedAsync();

        await _surveyResponseStatusTypeSeeder.SeedAsync();

        await _questionnaireVersionStatusTypeSeeder.SeedAsync();

        await _roleSeeder.SeedAsync();


        await _jobSeeder.SeedAsync();
    }
}