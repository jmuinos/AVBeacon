using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Recruiters;
using AvBeacon.Domain.Users.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasDiscriminator(u => u.UserType)
               .HasValue<User>(UserType.Base)
               .HasValue<Recruiter>(UserType.Recruiter)
               .HasValue<Applicant>(UserType.Applicant);

        builder.OwnsOne(user => user.FirstName, firstNameBuilder =>
        {
            firstNameBuilder.WithOwner();

            firstNameBuilder.Property(firstName => firstName.Value)
                            .HasColumnName(nameof(User.FirstName))
                            .HasMaxLength(FirstName.MaxLength)
                            .IsRequired();
        });

        builder.OwnsOne(user => user.LastName, lastNameBuilder =>
        {
            lastNameBuilder.WithOwner();

            lastNameBuilder.Property(lastName => lastName.Value)
                           .HasColumnName(nameof(User.LastName))
                           .HasMaxLength(LastName.MaxLength)
                           .IsRequired();
        });

        builder.OwnsOne(user => user.Email, emailBuilder =>
        {
            emailBuilder.WithOwner();

            emailBuilder.Property(email => email.Value)
                        .HasColumnName(nameof(User.Email))
                        .HasMaxLength(Email.MaxLength)
                        .IsRequired();
        });

        builder.Property<string>("_passwordHash")
               .HasField("_passwordHash")
               .HasColumnName("PasswordHash")
               .IsRequired();

        builder.Property(user => user.CreatedOnUtc).IsRequired();
        builder.Property(user => user.ModifiedOnUtc);
        builder.Property(user => user.DeletedOnUtc);
        builder.Property(user => user.Deleted).HasDefaultValue(false);
        builder.HasQueryFilter(user => !user.Deleted);

        builder.Ignore(user => user.FullName);
    }
}