using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.HasBaseType<User>();

        // Relación muchos a muchos con Skill
        builder.HasMany(a => a.Skills)
            .WithMany(s => s.Applicants);

        // Relación uno a muchos con JobApplication
        builder.HasMany(a => a.JobApplications)
            .WithOne(ja => ja.Applicant)
            .HasForeignKey(ja => ja.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos con Education
        builder.HasMany(a => a.Educations)
            .WithOne(e => e.Applicant)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos con Experience
        builder.HasMany(a => a.Experiences)
            .WithOne(e => e.Applicant)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}