using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class SurveyResponseStatusTypeConfiguration : IEntityTypeConfiguration<SurveyResponseStatusType>
{
    public void Configure(EntityTypeBuilder<SurveyResponseStatusType> builder)
    {
        builder.ToTable("SurveyResponseStatusTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Order)
               .IsRequired();

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasIndex(x => x.Order)
               .IsUnique();

        builder.HasIndex(x => x.Title)
               .IsUnique();
    }
}
