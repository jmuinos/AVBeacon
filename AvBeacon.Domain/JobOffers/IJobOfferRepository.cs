using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.JobOffers;

public interface IJobOfferRepository : IGenericRepository<JobOffer>
{
    Task<List<JobOffer>> SearchByTitleAsync(string titleText, CancellationToken cancellationToken = default);
}