using AvBeacon.Domain._Interfaces;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Educations;
using AvBeacon.Domain.Experiences;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Skills;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Core.Data;

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

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}