using AvBeacon.Domain.Entities;
using AvBeacon.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description)
               .HasMaxLength(500)
               .IsRequired();

        builder.Property(e => e.Start)
               .IsRequired(false);

        builder.Property(e => e.End)
               .IsRequired(false);

        builder.Property(e => e.EducationType)
               .HasConversion(new EducationTypeConverter())
               .IsRequired();

        builder.HasOne(e => e.Applicant)
               .WithMany(a => a.Educations)
               .HasForeignKey(e => e.ApplicantId);
    }
}