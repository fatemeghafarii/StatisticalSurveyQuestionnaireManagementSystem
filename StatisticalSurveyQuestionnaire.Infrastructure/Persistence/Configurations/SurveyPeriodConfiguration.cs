using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class SurveyPeriodConfiguration : IEntityTypeConfiguration<SurveyPeriod>
{
    public void Configure(EntityTypeBuilder<SurveyPeriod> builder)
    {
        builder.ToTable("SurveyPeriods");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.StartDate)
              .IsRequired();

        builder.Property(x => x.EndDate)
               .IsRequired();

        builder.Property(x => x.IsActive)
               .IsRequired();

        builder.HasIndex(x => x.Title)
               .IsUnique();
    }
}