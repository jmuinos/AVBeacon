using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasMany(s => s.ApplicantSkills)
               .WithOne(aS => aS.Skill)
               .HasForeignKey(aS => aS.SkillId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}