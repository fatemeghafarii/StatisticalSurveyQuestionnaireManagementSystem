using Microsoft.EntityFrameworkCore;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    //آخر سر چک کن اگر پراپرتی رفرنس نداشت در جای دیگه ایی از لایه اپلیکیشن حذفش کن 
    DbSet<Answer> Answers { get; }
    DbSet<City> Cities { get; }
    DbSet<EducationLevel> EducationLevels { get; }
    DbSet<Household> Households { get; }
    DbSet<Job> Jobs { get; }
    DbSet<MaritalStatus> MaritalStatuses { get; }
    DbSet<Person> Persons { get; }
    DbSet<Province> Provinces { get; }
    DbSet<Question> Questions { get; }
    DbSet<Questionnaire> Questionnaires { get; }
    DbSet<QuestionnaireVersion> QuestionnaireVersions { get; }
    DbSet<QuestionnaireVersionStatusType> QuestionnaireVersionStatusTypes { get; }
    DbSet<QuestionOption> QuestionOptions { get; }
    DbSet<QuestionType> QuestionTypes { get; }
    DbSet<Role> Roles { get; }
    DbSet<SurveyPeriod> SurveyPeriods { get; }
    DbSet<SurveyResponse> SurveyResponses { get; }
    DbSet<SurveyResponseStatusType> SurveyResponseStatusTypes { get; }
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}
