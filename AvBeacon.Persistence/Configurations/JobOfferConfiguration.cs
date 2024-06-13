using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.HasKey(jo => jo.Id);

        builder.Property(jo => jo.Title)
               .HasConversion(v => v.Value, v => Title.Create(v).Value);

        builder.Property(jo => jo.Description)
               .HasConversion(v => v.Value, v => Description.Create(v).Value);

        builder.HasOne(jo => jo.Recruiter)
               .WithMany(r => r.JobOffers)
               .HasForeignKey(jo => jo.RecruiterId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}