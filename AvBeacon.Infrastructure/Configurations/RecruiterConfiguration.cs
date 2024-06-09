using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvBeacon.Infrastructure.Configurations;

public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
{
    public void Configure(EntityTypeBuilder<Recruiter> builder)
    {
        builder.HasMany(r => r.JobOffers)
               .WithOne(jo => jo.Recruiter)
               .HasForeignKey(jo => jo.RecruiterId)
               .OnDelete(DeleteBehavior.Cascade); // Eliminar en cascada
    }
}