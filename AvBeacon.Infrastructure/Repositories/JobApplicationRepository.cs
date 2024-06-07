using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class JobApplicationRepository(ApplicationDbContext context)
    : GenericRepository<JobApplication>(context), IJobApplicationRepository
{
    public async Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.Where(ja => ja.ApplicantId == applicantId).ToListAsync(cancellationToken);
    }

    public async Task<List<JobApplication>> GetByApplicantIdAndStateAsync(Guid applicantId, JobApplicationState state,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.Where(ja => ja.ApplicantId == applicantId && ja.State == state)
                          .ToListAsync(cancellationToken);
    }

    // public async Task<List<JobApplication>> GetByRecruiterIdAsync(Guid recruiterId,
    //     CancellationToken cancellationToken = default)
    // {
    //     return await DbSet.Include(ja => ja.JobOffer)
    //                       .Where(ja => ja.JobOffer.RecruiterId == recruiterId)
    //                       .ToListAsync(cancellationToken);
    // }
}