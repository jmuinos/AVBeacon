using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.HasKey(e => e.Id);

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
                              .HasMaxLength(Title.MaxLength)
                              .IsRequired();
        });
        builder.Property(e => e.Start)
               .IsRequired(false);

        builder.Property(e => e.End)
               .IsRequired(false);

        // Relación uno a muchos con Applicant
        builder.HasOne<Applicant>()
               .WithMany()
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}