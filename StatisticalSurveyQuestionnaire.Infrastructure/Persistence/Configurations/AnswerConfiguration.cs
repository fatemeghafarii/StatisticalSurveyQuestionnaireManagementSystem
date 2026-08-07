using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;
public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Value)
               .HasMaxLength(1000);

        builder.HasOne(x => x.Question)
               .WithMany(x => x.Answers)
               .HasForeignKey(x => x.QuestionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.SurveyResponse)
               .WithMany(x => x.Answers)
               .HasForeignKey(x => x.SurveyResponseId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.QuestionOption)
               .WithMany(x => x.Answers)
               .HasForeignKey(x => x.QuestionOptionId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.SurveyResponseId, x.QuestionId})
               .IsUnique();
    }
}
