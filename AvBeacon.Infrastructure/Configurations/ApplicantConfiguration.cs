using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.HasMany(a => a.Educations)
               .WithOne(e => e.Applicant)
               .HasForeignKey(e => e.ApplicantId);

        builder.HasMany(a => a.Experiences)
               .WithOne(e => e.Applicant)
               .HasForeignKey(e => e.ApplicantId);

        builder.HasMany(a => a.Skills)
               .WithMany(s => s.Applicants)
               .UsingEntity<Dictionary<string, object>>(
                                                        "ApplicantSkill",
                                                        j => j.HasOne<Skill>().WithMany().HasForeignKey("SkillId"),
                                                        j => j.HasOne<Applicant>().WithMany()
                                                              .HasForeignKey("ApplicantId")
                                                       );

        builder.HasMany(a => a.JobApplications)
               .WithOne(ja => ja.Applicant)
               .HasForeignKey(ja => ja.ApplicantId);
    }
}