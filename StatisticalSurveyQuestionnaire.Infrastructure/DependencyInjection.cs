using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed;
using StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Seed.Seeders;
using StatisticalSurveyQuestionnaire.Infrastructure.Services;

namespace StatisticalSurveyQuestionnaire.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        
        services.AddScoped<IJsonFileReader, JsonFileReader>();

        services.AddScoped<ICodeGenerator, CodeGenerator>();

        services.AddScoped<ProvinceSeeder>();
        services.AddScoped<CitySeeder>();

        services.AddScoped<EducationLevelSeeder>();
        services.AddScoped<MaritalStatusSeeder>();
        services.AddScoped<QuestionTypeSeeder>();
        services.AddScoped<SurveyResponseStatusTypeSeeder>();
        services.AddScoped<RoleSeeder>();

        services.AddScoped<JobSeeder>();

        services.AddScoped<DbInitializer>();

        return services;
    }
}




