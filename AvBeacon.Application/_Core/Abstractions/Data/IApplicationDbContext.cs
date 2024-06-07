using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application._Core.Abstractions.Data;

public interface IApplicationDbContext
{
    DbSet<User> Users { get; }
    DbSet<Applicant> Applicants { get; }
    DbSet<Recruiter> Recruiters { get; }
    DbSet<Education> Educations { get; }
    DbSet<Experience> Experiences { get; }
    DbSet<Skill> Skills { get; }
    DbSet<JobApplication> JobApplications { get; }
    DbSet<JobOffer> JobOffers { get; }

    // TODO Probar en los get de los repo para realizar las queries cqrs y no abstraer doblemente la lectura de db con EF, que ya tiene su propia abstracción por ser un ORM
    // public Task<int> ExecuteSqlAsync(string sql, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default)
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}