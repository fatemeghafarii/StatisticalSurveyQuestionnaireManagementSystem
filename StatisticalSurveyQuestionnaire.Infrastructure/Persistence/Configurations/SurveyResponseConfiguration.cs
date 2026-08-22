using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class SurveyResponseConfiguration : IEntityTypeConfiguration<SurveyResponse>
{
    public void Configure(EntityTypeBuilder<SurveyResponse> builder)
    {
        builder.ToTable("SurveyResponses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.StartedDate)
               .IsRequired(false);

        builder.Property(x => x.CompletedDate)
               .IsRequired(false);

        builder.HasOne(x => x.Status)
               .WithMany(x => x.SurveyResponses)
               .HasForeignKey(x => x.StatusId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Household)
               .WithMany(x => x.SurveyResponses)
               .HasForeignKey(x => x.HouseholdId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.QuestionnaireVersion)
               .WithMany(x => x.SurveyResponses)
               .HasForeignKey(x => x.QuestionnaireVersionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SurveyPeriod)
               .WithMany(x => x.SurveyResponses)
               .HasForeignKey(x => x.SurveyPeriodId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.HouseholdId,
            x.QuestionnaireVersionId,
            x.SurveyPeriodId
        })
        .IsUnique();
    }
}
public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
{
    public void Configure(EntityTypeBuilder<AnswerOption> builder)
    {
        builder.ToTable("AnswerOptions");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Answer)
            .WithMany(x => x.AnswerOptions)
            .HasForeignKey(x => x.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.QuestionOption)
            .WithMany(x => x.AnswerOptions)
            .HasForeignKey(x => x.QuestionOptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.AnswerId,
            x.QuestionOptionId
        })
        .IsUnique();
    }
}