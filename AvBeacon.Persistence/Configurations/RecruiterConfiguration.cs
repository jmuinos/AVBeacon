using AvBeacon.Domain.Users.Recruiters;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
{
    public void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        builder.HasMany<JobOffer>()
               .WithOne()
               .HasForeignKey(jo => jo.RecruiterId)
               .OnDelete(DeleteBehavior.Cascade); 
    }
}