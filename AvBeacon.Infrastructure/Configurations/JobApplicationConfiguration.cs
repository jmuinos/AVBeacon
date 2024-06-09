using AvBeacon.Domain.Entities;
using AvBeacon.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(ja => ja.Id);

        builder.Property(ja => ja.State)
               .HasConversion(new JobApplicationStateConverter())
               .IsRequired();

        builder.HasOne(ja => ja.Applicant)
               .WithMany(a => a.JobApplications)
               .HasForeignKey(ja => ja.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade); // Eliminar en cascada

        builder.HasOne(ja => ja.JobOffer)
               .WithMany(jo => jo.JobApplications)
               .HasForeignKey(ja => ja.JobOfferId)
               .OnDelete(DeleteBehavior.Restrict); // Evitar ciclos
    }
}