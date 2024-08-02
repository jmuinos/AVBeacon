using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(ja => ja.Id);

        // Relación uno a muchos con Applicant
        builder.HasOne<Applicant>()
               .WithMany()
               .HasForeignKey(ja => ja.ApplicantId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired();

        // Relación uno a muchos con JobOffer
        builder.HasOne<JobOffer>()
               .WithMany()
               .HasForeignKey(ja => ja.JobOfferId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired();

        builder.OwnsOne(ja => ja.State, jobApplicationStateBuilder =>
        {
            jobApplicationStateBuilder.WithOwner();
            jobApplicationStateBuilder.Property(state => state.Value)
                                      .HasColumnName(nameof(JobApplication.State))
                                      .IsRequired();
            jobApplicationStateBuilder.Ignore(state => state.Name);
        });
    }
}