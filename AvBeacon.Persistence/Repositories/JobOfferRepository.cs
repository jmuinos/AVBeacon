using AvBeacon.Domain.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

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