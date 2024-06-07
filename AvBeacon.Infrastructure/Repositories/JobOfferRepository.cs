using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository
{
    public async Task<List<JobOffer>> SearchByTitleAsync(string titleText,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(jo => EF.Functions.Like(jo.Title, $"%{titleText}%"))
                    .ToListAsync(cancellationToken);
    }
}