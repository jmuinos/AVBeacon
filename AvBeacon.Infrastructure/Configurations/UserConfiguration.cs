using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.FirstName)
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(u => u.LastName)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.Email)
               .IsRequired();

        builder.Property<string>("_passwordHash")
               .IsRequired()
               .HasColumnName("PasswordHash");

        builder.HasDiscriminator<string>("UserType")
               .HasValue<User>("User")
               .HasValue<Applicant>("Applicant")
               .HasValue<Recruiter>("Recruiter");
    }
}