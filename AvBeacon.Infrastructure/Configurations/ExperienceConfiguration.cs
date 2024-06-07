using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(e => e.Description)
               .HasMaxLength(500)
               .IsRequired(false);

        builder.Property(e => e.RecruiterName)
               .HasMaxLength(100)
               .IsRequired(false);

        builder.Property(e => e.Start)
               .IsRequired(false);

        builder.Property(e => e.End)
               .IsRequired(false);

        builder.HasOne(e => e.Applicant)
               .WithMany(a => a.Experiences)
               .HasForeignKey(e => e.ApplicantId);
    }
}