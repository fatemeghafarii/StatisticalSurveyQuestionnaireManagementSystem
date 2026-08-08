using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class QuestionnaireVersionStatusTypeConfiguration : IEntityTypeConfiguration<QuestionnaireVersionStatusType>
{
    public void Configure(EntityTypeBuilder<QuestionnaireVersionStatusType> builder)
    {
        builder.ToTable("QuestionnaireVersionStatusTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Title)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Order)
               .IsRequired();

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasIndex(x => new { x.Code, x.Title, x.Order })
               .IsUnique();
    }
}