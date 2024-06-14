using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.FirstName)
            .HasConversion(f => f.Value, v => FirstName.Create(v).Value)
            .IsRequired();

        builder.Property(a => a.LastName)
            .HasConversion(l => l.Value, v => LastName.Create(v).Value)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasConversion(e => e.Value, v => Email.Create(v).Value)
            .IsRequired();

        builder.Ignore(a => a.FullName);

        // Relación muchos a muchos con Skill
        builder.HasMany(a => a.Skills)
            .WithMany(s => s.Applicants);

        // Relación uno a muchos con JobApplication
        builder.HasMany(a => a.JobApplications)
            .WithOne(ja => ja.Applicant)
            .HasForeignKey(ja => ja.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos con Education
        builder.HasMany(a => a.Educations)
            .WithOne(e => e.Applicant)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos con Experience
        builder.HasMany(a => a.Experiences)
            .WithOne(e => e.Applicant)
            .HasForeignKey(e => e.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasDiscriminator<string>("User_Type")
            .HasValue<User>("User")
            .HasValue<Recruiter>("Recruiter")
            .HasValue<Applicant>("Applicant");
    }
}