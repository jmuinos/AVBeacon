using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Applicants.Skills;
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
        
        builder.Property(user => user.CreatedOnUtc).IsRequired();

        builder.Property(user => user.ModifiedOnUtc);

        builder.Property(user => user.DeletedOnUtc);

        builder.Property(user => user.Deleted).HasDefaultValue(false);

        builder.HasQueryFilter(user => !user.Deleted);
    }
}