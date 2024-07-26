using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
            .HasConversion(t => t.Value, v => Title.Create(v).Value)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasConversion(d => d.Value, v => Description.Create(v).Value)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(e => e.Start)
            .IsRequired(false);

        builder.Property(e => e.End)
            .IsRequired(false);

        builder.HasOne(e => e.Applicant)
            .WithMany(a => a.Experiences)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos con Applicant
        builder.HasOne(e => e.Applicant)
            .WithMany(a => a.Experiences)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    }
}