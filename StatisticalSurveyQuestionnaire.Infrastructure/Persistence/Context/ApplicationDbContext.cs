using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Context;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<AnswerOption> AnswerOptions { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<EducationLevel> EducationLevels { get; set; } = null!;
    public DbSet<Household> Households { get; set; } = null!;
    public DbSet<Job> Jobs { get; set; } = null!;
    public DbSet<MaritalStatus> MaritalStatuses { get; set; } = null!;
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<Province> Provinces { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Questionnaire> Questionnaires { get; set; } = null!;
    public DbSet<QuestionnaireVersion> QuestionnaireVersions { get; set; } = null!;
    public DbSet<QuestionnaireVersionStatusType> QuestionnaireVersionStatusTypes { get; set; } = null!;
    public DbSet<QuestionOption> QuestionOptions { get; set; } = null!;
    public DbSet<QuestionType> QuestionTypes { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<SurveyPeriod> SurveyPeriods { get; set; } = null!;
    public DbSet<SurveyResponse> SurveyResponses { get; set; } = null!;
    public DbSet<SurveyResponseStatusType> SurveyResponseStatusTypes { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
