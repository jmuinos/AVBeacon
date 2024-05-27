using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Recruiter> Recruiters { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<JobOffer> JobOffers { get; set; }

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