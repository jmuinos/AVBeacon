using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain.Entities;
using AvBeacon.Infrastructure.Configurations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }


    public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters,
        CancellationToken cancellationToken = default)
    {
        return Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
    }

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        return Database.BeginTransactionAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicantConfiguration());
        modelBuilder.ApplyConfiguration(new RecruiterConfiguration());
        modelBuilder.ApplyConfiguration(new JobOfferConfiguration());
        modelBuilder.ApplyConfiguration(new JobApplicationConfiguration());
        modelBuilder.ApplyConfiguration(new SkillConfiguration());
        modelBuilder.ApplyConfiguration(new EducationConfiguration());
        modelBuilder.ApplyConfiguration(new ExperienceConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}