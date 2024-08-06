using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobApplicationConfiguration : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.HasKey(ja => ja.Id);
        
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

        builder.Property(ja => ja.CreatedOnUtc).IsRequired();
        builder.Property(ja => ja.ModifiedOnUtc);
        builder.Property(ja => ja.DeletedOnUtc);
        builder.Property(ja => ja.Deleted).HasDefaultValue(false);
        builder.HasQueryFilter(ja => !ja.Deleted);
    }
}