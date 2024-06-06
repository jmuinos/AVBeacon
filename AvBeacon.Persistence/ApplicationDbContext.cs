using AvBeacon.Application.Core.Data;
using AvBeacon.Domain._Interfaces;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Skills;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence;

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

        // Configuración de la relación entre JobApplication y Applicant
        modelBuilder.Entity<JobApplication>()
                    .HasOne(ja => ja.Applicant)
                    .WithMany(a => a.JobApplications)
                    .HasForeignKey(ja => ja.ApplicantId);

        // Configuración de la relación entre JobOffer y Recruiter
        modelBuilder.Entity<JobOffer>()
                    .HasOne(jo => jo.Recruiter)
                    .WithMany(r => r.JobOffers)
                    .HasForeignKey(jo => jo.RecruiterId);

        // Configuración de la relación entre Applicant y Education
        modelBuilder.Entity<Applicant>()
                    .HasMany(a => a.Educations)
                    .WithOne()
                    .HasForeignKey(e => e.ApplicantId);

        // Configuración de la relación entre Applicant y Experience
        modelBuilder.Entity<Applicant>()
                    .HasMany(a => a.Experiences)
                    .WithOne()
                    .HasForeignKey(e => e.ApplicantId);

        // Configuración de la relación entre Applicant y Skill
        modelBuilder.Entity<Applicant>()
                    .HasMany(a => a.Skills)
                    .WithOne()
                    .HasForeignKey(s => s.ApplicantId);
    }
}