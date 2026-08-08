using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class QuestionnaireVersionConfiguration : IEntityTypeConfiguration<QuestionnaireVersion>
{
    public void Configure(EntityTypeBuilder<QuestionnaireVersion> builder)
    {
        builder.ToTable("QuestionnaireVersions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.EffectiveDate)
               .IsRequired();

        builder.Property(x => x.IsActive)
               .IsRequired();

        builder.HasOne(x => x.Questionnaire)
               .WithMany(x => x.QuestionnaireVersions)
               .HasForeignKey(x => x.QuestionnaireId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Status)
               .WithMany(x => x.QuestionnaireVersions)
               .HasForeignKey(x => x.StatusId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x =>
        new
        {
            x.QuestionnaireId,
            x.VersionNumber
        })
        .IsUnique();
    }
}