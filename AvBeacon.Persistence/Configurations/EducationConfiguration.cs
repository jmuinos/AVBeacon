using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants.Educations;
using AvBeacon.Domain.Users.Applicants.Experiences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.EducationType)
               .IsRequired()
               .HasConversion(et => et.Value, etv => EducationType.FromValue(etv).Value);

        builder.OwnsOne(e => e.Title, titleBuilder =>
        {
            titleBuilder.WithOwner();

            titleBuilder.Property(title => title.Value)
                        .HasColumnName(nameof(Experience.Title))
                        .HasMaxLength(Title.MaxLength)
                        .IsRequired();
        });

        builder.OwnsOne(e => e.Description, descriptionBuilder =>
        {
            descriptionBuilder.WithOwner();

            descriptionBuilder.Property(description => description.Value)
                              .HasColumnName(nameof(Experience.Description))
                              .HasMaxLength(Description.MaxLength)
                              .IsRequired();
        });

        builder.Property(e => e.CreatedOnUtc).IsRequired();
        builder.Property(e => e.ModifiedOnUtc);
        builder.Property(e => e.DeletedOnUtc);
        builder.Property(e => e.Deleted).HasDefaultValue(false);
        builder.HasQueryFilter(e => !e.Deleted);
    }
}