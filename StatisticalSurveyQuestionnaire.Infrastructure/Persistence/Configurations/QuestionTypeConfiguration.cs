using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
{
    public void Configure(EntityTypeBuilder<QuestionType> builder)
    {
        builder.ToTable("QuestionTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(x => x.Title)
               .HasMaxLength(100)
               .IsRequired();
    
        builder.HasIndex(x => new { x.Code, x.Title, x.Order })
               .IsUnique();
    } 
}
