using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
{
    public void Configure(EntityTypeBuilder<QuestionOption> builder)
    {
        builder.ToTable("QuestionOptions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text)
               .HasMaxLength(500)
               .IsRequired();

        builder.Property(x => x.Order)
               .IsRequired();

        builder.HasOne(x => x.Question)
               .WithMany(x => x.QuestionOptions)
               .HasForeignKey(x => x.QuestionId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.QuestionId, x.Order })
               .IsUnique();
    }
}
