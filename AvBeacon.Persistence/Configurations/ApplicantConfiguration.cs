using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.HasMany(a => a.Educations)
               .WithOne(e => e.Applicant)
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Experiences)
               .WithOne(e => e.Applicant)
               .HasForeignKey(e => e.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.JobApplications)
               .WithOne(ja => ja.Applicant)
               .HasForeignKey(ja => ja.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(e => e.Skills)
               .WithMany(e => e.Applicants)
               .UsingEntity<ApplicantSkill>(
                                            left => left
                                                   .HasOne<Skill>()
                                                   .WithMany()
                                                   .HasForeignKey("SkillId")
                                                   .HasPrincipalKey(s => s.Id)
                                                   .OnDelete(DeleteBehavior.Cascade),
                                            right => right
                                                    .HasOne<Applicant>()
                                                    .WithMany()
                                                    .HasForeignKey("ApplicantId")
                                                    .HasPrincipalKey(a => a.Id)
                                                    .OnDelete(DeleteBehavior.Cascade),
                                            join => join
                                               .HasKey("ApplicantId", "SkillId"));
    }
}