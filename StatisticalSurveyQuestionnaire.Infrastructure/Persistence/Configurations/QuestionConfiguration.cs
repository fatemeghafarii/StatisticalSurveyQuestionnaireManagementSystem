using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("Questions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text)
               .HasMaxLength(1000)
               .IsRequired();

        builder.Property(x => x.Order)
               .IsRequired();

        builder.HasOne(x => x.QuestionnaireVersion)
               .WithMany(x => x.Questions)
               .HasForeignKey(x => x.QuestionnaireVersionId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.QuestionType)
               .WithMany(x => x.Questions)
               .HasForeignKey(x => x.QuestionTypeId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.QuestionnaireVersionId, x.Order })
               .IsUnique();
    }
}
