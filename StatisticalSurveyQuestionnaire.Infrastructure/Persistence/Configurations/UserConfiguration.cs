using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
               .IsRequired()
               .HasMaxLength(100);

        builder.HasIndex(x => x.Username)
               .IsUnique();

        builder.Property(x => x.PasswordHash)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasOne(x => x.Role)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.RoleId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
