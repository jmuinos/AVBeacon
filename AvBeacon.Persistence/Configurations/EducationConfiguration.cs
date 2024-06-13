using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Enumerations;
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

        builder.Property(e => e.Title)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(e => e.Description)
               .IsRequired(false)
               .HasMaxLength(400);

        builder.HasOne(e => e.Applicant)
               .WithMany(a => a.Educations)
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}