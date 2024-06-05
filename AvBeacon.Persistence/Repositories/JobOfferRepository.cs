using AvBeacon.Domain.JobOffers;

namespace AvBeacon.Persistence.Repositories;

public class JobOfferRepository(ApplicationDbContext context)
    : GenericRepository<JobOffer>(context), IJobOfferRepository
{
    // TODO
    public Task<JobOffer?> GetAllByRecruiterId<T>(Guid applicantId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<JobOffer?> GetAllBySimilarTitle<T>(string title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}