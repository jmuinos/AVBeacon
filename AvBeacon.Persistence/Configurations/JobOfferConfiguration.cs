using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Persistence.Configurations;

public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.HasKey(jo => jo.Id);

        builder.Property(jo => jo.Title)
            .HasConversion(t => t.Value, v => Title.Create(v).Value)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(jo => jo.Description)
            .HasConversion(d => d.Value, v => Description.Create(v).Value)
            .HasMaxLength(800)
            .IsRequired();

        // Relación uno a muchos con Recruiter
        builder.HasOne(jo => jo.Recruiter)
            .WithMany(r => r.JobOffers)
            .HasForeignKey(jo => jo.RecruiterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}