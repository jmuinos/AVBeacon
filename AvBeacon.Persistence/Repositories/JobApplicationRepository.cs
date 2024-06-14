using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class JobApplicationRepository(IDbContext context)
    : GenericRepository<JobApplication>(context), IJobApplicationRepository
{
    public async Task<List<JobApplication>> GetByApplicantIdAsync(Guid applicantId,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<JobApplication>()
            .Where(ja => ja.ApplicantId == applicantId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<JobApplication>> GetByJobOfferIdAsync(Guid jobOfferId,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<JobApplication>()
            .Where(ja => ja.JobOfferId == jobOfferId)
            .ToListAsync(cancellationToken);
    }
}