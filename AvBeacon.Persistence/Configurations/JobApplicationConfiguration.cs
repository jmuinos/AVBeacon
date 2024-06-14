using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(ja => ja.Id);

        builder.Property(ja => ja.State)
            .HasConversion(s => s.Value, v => JobApplicationState.FromValue(v).Value)
            .IsRequired();

        // Relación uno a muchos con Applicant
        builder.HasOne(ja => ja.Applicant)
            .WithMany(a => a.JobApplications)
            .HasForeignKey(ja => ja.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación uno a muchos con JobOffer
        builder.HasOne(ja => ja.JobOffer)
            .WithMany(jo => jo.JobApplications)
            .HasForeignKey(ja => ja.JobOfferId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}