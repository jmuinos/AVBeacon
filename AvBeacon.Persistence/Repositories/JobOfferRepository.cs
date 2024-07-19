using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Recruiters;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class JobOfferRepository(IDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository
{
    public async Task<List<JobOffer>> GetByRecruiterIdAsync(Guid recruiterId,
        CancellationToken cancellationToken = default)
    {
        return await Context.Set<JobOffer>()
            .Where(jo => jo.RecruiterId == recruiterId)
            .ToListAsync(cancellationToken);
    }
}