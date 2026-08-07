using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class JobConfiguration : IEntityTypeConfiguration<Job>
{
    public void Configure(EntityTypeBuilder<Job> builder)
    {
        builder.ToTable("Jobs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Code)
               .HasMaxLength(50);

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasOne(x => x.ParentJob)
               .WithMany(x => x.ChildJobs)
               .HasForeignKey(x => x.ParentJobId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => x.Code)
               .IsUnique();
    }
}
