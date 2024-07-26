using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
            .HasConversion(t => t.Value, v => Title.Create(v).Value)
            .IsRequired();

        // Relación muchos a muchos con Applicant
        builder.HasMany(s => s.Applicants)
            .WithMany(a => a.Skills);
    }
    }
}