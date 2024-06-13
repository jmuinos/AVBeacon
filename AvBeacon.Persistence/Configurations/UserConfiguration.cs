using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasDiscriminator<string>("UserType")
               .HasValue<Applicant>("Applicant")
               .HasValue<Recruiter>("Recruiter");

        builder.Property(u => u.FirstName)
               .HasConversion(f => f.Value, v => FirstName.Create(v).Value)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.LastName)
               .HasConversion(l => l.Value, v => LastName.Create(v).Value)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasConversion(e => e.Value, v => Email.Create(v).Value)
               .HasMaxLength(256)
               .IsRequired();
    }
}