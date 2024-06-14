using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Persistence.Configurations;

public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
{
    public void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.FirstName)
            .HasConversion(f => f.Value, v => FirstName.Create(v).Value)
            .IsRequired();

        builder.Property(r => r.LastName)
            .HasConversion(l => l.Value, v => LastName.Create(v).Value)
            .IsRequired();

        builder.Property(r => r.Email)
            .HasConversion(e => e.Value, v => Email.Create(v).Value)
            .IsRequired();

        builder.Ignore(r => r.FullName);

        // Relación uno a muchos con JobOffer
        builder.HasMany(r => r.JobOffers)
            .WithOne(jo => jo.Recruiter)
            .HasForeignKey(jo => jo.RecruiterId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}