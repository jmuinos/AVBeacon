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
               .UsingEntity<Dictionary<string, object>>(
                                                        "ApplicantSkill",
                                                        applicantSkill =>
                                                            applicantSkill.HasOne<Applicant>().WithMany()
                                                                          .HasForeignKey("ApplicantId")
                                                                          .OnDelete(DeleteBehavior.Cascade),
                                                        applicantSkill =>
                                                            applicantSkill.HasOne<Skill>().WithMany()
                                                                          .HasForeignKey("SkillId")
                                                                          .OnDelete(DeleteBehavior.Cascade),
                                                        applicantSkill =>
                                                        {
                                                            applicantSkill.HasKey("ApplicantId", "SkillId");
                                                            applicantSkill.HasIndex("ApplicantId", "SkillId")
                                                                          .IsUnique(); // Ensure uniqueness
                                                        });
    }
}