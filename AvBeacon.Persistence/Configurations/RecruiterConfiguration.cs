using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        builder.HasBaseType<User>();

        // Relación uno a muchos con JobOffer
        builder.HasMany(r => r.JobOffers)
            .WithOne(jo => jo.Recruiter)
            .HasForeignKey(jo => jo.RecruiterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    }
}