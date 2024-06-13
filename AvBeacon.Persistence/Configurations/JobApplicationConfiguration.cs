using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(ja => ja.Id);
        builder.Property(ja => ja.State).IsRequired();

        builder.HasOne(ja => ja.JobOffer)
               .WithMany(jo => jo.JobApplications)
               .HasForeignKey(ja => ja.JobOfferId)
               .OnDelete(DeleteBehavior.ClientCascade);
    }
}