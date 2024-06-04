using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Skills;
using AvBeacon.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<JobOffer> JobOffers { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Education> Educations { get; set; }

    public new Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // Configuraciones de modelos adicionales
    //     base.OnModelCreating(modelBuilder);
    // }
}