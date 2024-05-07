using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Candidate> Candidates { get; }
    DbSet<Recruiter> Recruiters { get; }
    DbSet<Education> Educations { get; }
    DbSet<Experience> Experiences { get; }
    DbSet<Skill> Skills { get; }
    DbSet<JobApplication> JobApplications { get; }
    DbSet<JobOffer> JobOffers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}