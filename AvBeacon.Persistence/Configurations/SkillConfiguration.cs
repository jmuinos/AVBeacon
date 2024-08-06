using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants.Skills;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

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