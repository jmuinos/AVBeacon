using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Infrastructure.Repositories;

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository
{
    // TODO
    public Task<JobOffer?> GetAllByRecruiterId<T>(Guid applicantId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<JobOffer?> GetAllBySimilarTitle<T>(Title title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}