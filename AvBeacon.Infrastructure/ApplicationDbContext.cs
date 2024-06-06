using AvBeacon.Application.Core.Data;
using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Applicant> Applicants => Set<Applicant>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Recruiter> Recruiters => Set<Recruiter>();
    public DbSet<JobOffer> JobOffers => Set<JobOffer>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<Education> Educations => Set<Education>();

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar la relación entre Applicant y JobApplication
        modelBuilder.Entity<JobApplication>()
                    .HasOne(ja => ja.Applicant)
                    .WithMany()
                    .HasForeignKey(ja => ja.ApplicantId)
                    .OnDelete(DeleteBehavior.Cascade);

        // Configurar la relación entre JobApplication y JobOffer
        modelBuilder.Entity<JobApplication>()
                    .HasOne(ja => ja.JobOffer)
                    .WithMany()
                    .HasForeignKey(ja => ja.JobOfferId)
                    .OnDelete(DeleteBehavior.Cascade);

        // Configurar la relación entre Recruiter y JobOffer
        modelBuilder.Entity<JobOffer>()
                    .HasOne(jo => jo.Recruiter)
                    .WithMany(r => r.JobOffers)
                    .HasForeignKey(jo => jo.RecruiterId)
                    .OnDelete(DeleteBehavior.Cascade);

        // Configurar la relación entre Applicant y Education
        modelBuilder.Entity<Education>()
                    .HasOne<Applicant>()
                    .WithMany(a => a.Educations)
                    .HasForeignKey(e => e.ApplicantId)
                    .OnDelete(DeleteBehavior.Cascade);

        // Configurar la relación entre Applicant y Experience
        modelBuilder.Entity<Experience>()
                    .HasOne<Applicant>()
                    .WithMany(a => a.Experiences)
                    .HasForeignKey(e => e.ApplicantId)
                    .OnDelete(DeleteBehavior.Cascade);

        // Configurar la relación entre Applicant y Skill
        modelBuilder.Entity<Skill>()
                    .HasOne<Applicant>()
                    .WithMany(a => a.Skills)
                    .HasForeignKey(s => s.ApplicantId)
                    .OnDelete(DeleteBehavior.Cascade);
    }
}