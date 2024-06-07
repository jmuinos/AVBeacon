using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Title)
               .IsRequired();
        builder.HasMany(s => s.Applicants)
               .WithMany(a => a.Skills)
               .UsingEntity<Dictionary<string, object>>("ApplicantSkill",
                                                        sa => sa.HasOne<Applicant>().WithMany()
                                                                .HasForeignKey("ApplicantId"),
                                                        sa => sa.HasOne<Skill>().WithMany().HasForeignKey("SkillId")
                                                       );
    }
}