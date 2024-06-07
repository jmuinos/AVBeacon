using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IJobOfferRepository : IGenericRepository<JobOffer>
{
    Task<List<JobOffer>> SearchByTitleAsync(string titleText, CancellationToken cancellationToken = default);
}