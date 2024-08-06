using AvBeacon.Domain.Users.Recruiters;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
{
    public void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        // Explicitly including the collection of JobOffers for clarity and usability
        builder.HasMany<JobOffer>()
               .WithOne() // Optionally specify the reference navigation property back to Recruiter if available
               .HasForeignKey(jo => jo.RecruiterId)
               .OnDelete(DeleteBehavior
                             .Cascade); // Ensuring cascade delete is mirrored here, although not strictly necessary as it's already defined in JobOfferConfiguration
    }
}