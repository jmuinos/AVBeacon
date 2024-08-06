using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Applicants.Educations;
using AvBeacon.Domain.Users.Applicants.Experiences;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Applicants.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.HasMany<JobApplication>()
               .WithOne()
               .HasForeignKey(ja => ja.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<Experience>()
               .WithOne()
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<Education>()
               .WithOne()
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany<Skill>()
               .WithMany();
    }
}