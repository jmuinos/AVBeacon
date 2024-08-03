using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants;
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

        // Relación uno a muchos con Applicant
        builder.HasOne<Applicant>()
               .WithMany()
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

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
    }
}