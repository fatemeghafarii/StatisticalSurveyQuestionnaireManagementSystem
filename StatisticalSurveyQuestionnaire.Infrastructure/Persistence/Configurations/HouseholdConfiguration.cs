using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StatisticalSurveyQuestionnaire.Domain.Entities;

namespace StatisticalSurveyQuestionnaire.Infrastructure.Persistence.Configurations;

public class HouseholdConfiguration : IEntityTypeConfiguration<Household>
{
    public void Configure(EntityTypeBuilder<Household> builder)
    {
        builder.ToTable("Households");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(x => x.Code)
               .IsUnique();

        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(a => a.CityId)
                   .IsRequired();

            address.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(200);

            address.Property(a => a.Alley)
                   .HasMaxLength(100);

            address.Property(a => a.HouseNumber)
                   .HasMaxLength(20);

            address.Property(a => a.PostalCode)
                   .HasMaxLength(20);
        });
    }
}
