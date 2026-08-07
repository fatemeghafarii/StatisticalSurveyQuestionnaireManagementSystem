using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(x => x.Order)
               .IsRequired();
 
        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.HasIndex(x => x.Title)
               .IsUnique();
    }
}
