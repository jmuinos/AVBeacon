using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);
        // Relación muchos a muchos con Applicant
        builder.HasMany<Applicant>()
               .WithMany();

        builder.OwnsOne(skill => skill.Title, titleBuilder =>
        {
            titleBuilder.WithOwner();
            titleBuilder.Property(title => title.Value)
                        .HasColumnName(nameof(Skill.Title))
                        .HasMaxLength(Title.MaxLength)
                        .IsRequired();
        });
    }
}