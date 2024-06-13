using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class ApplicantSkillConfiguration : IEntityTypeConfiguration<ApplicantSkill>
{
    public void Configure(EntityTypeBuilder<ApplicantSkill> builder)
    {
        builder.HasKey(aS => new { aS.ApplicantId, aS.SkillId });

        builder.HasOne(aS => aS.Applicant)
               .WithMany(a => a.ApplicantSkills)
               .HasForeignKey(aS => aS.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(aS => aS.Skill)
               .WithMany(s => s.ApplicantSkills)
               .HasForeignKey(aS => aS.SkillId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}