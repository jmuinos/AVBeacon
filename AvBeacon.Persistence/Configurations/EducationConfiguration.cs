using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Enumerations;
using AvBeacon.Domain.ValueObjects;
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
            .HasConversion(t => t.Value, v => Title.Create(v).Value)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(e => e.Description)
            .HasConversion(d => d.Value, v => Description.Create(v).Value)
            .IsRequired(false)
            .HasMaxLength(500);

        builder.HasOne(e => e.Applicant)
            .WithMany(a => a.Educations)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}