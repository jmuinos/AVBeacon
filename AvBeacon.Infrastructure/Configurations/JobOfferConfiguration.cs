using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class JobOfferConfiguration : IEntityTypeConfiguration<JobOffer>
{
    public void Configure(EntityTypeBuilder<JobOffer> builder)
    {
        builder.HasKey(jo => jo.Id);

        builder.Property(jo => jo.Title)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(jo => jo.Description)
               .HasMaxLength(500)
               .IsRequired();

        builder.HasOne(jo => jo.Recruiter)
               .WithMany(r => r.JobOffers)
               .HasForeignKey(jo => jo.RecruiterId)
               .OnDelete(DeleteBehavior.Cascade); // Eliminar en cascada

        builder.HasMany(jo => jo.JobApplications)
               .WithOne(ja => ja.JobOffer)
               .HasForeignKey(ja => ja.JobOfferId)
               .OnDelete(DeleteBehavior.Restrict); // Evitar eliminación en cascada
    }
}