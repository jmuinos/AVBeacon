using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
            .HasConversion(f => f.Value, v => FirstName.Create(v).Value)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasConversion(l => l.Value, v => LastName.Create(v).Value)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasConversion(e => e.Value, v => Email.Create(v).Value)
            .IsRequired();

        builder.Ignore(u => u.FullName);

        builder.HasDiscriminator<string>("User_Type")
            .HasValue<Recruiter>("Recruiter")
            .HasValue<Applicant>("Applicant");
    }
}