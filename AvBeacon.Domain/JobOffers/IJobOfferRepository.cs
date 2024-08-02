using AvBeacon.Domain.Common;

namespace AvBeacon.Domain.JobOffers;

public interface IJobOfferRepository : IBaseRepository<JobOffer>
{
    Task<List<JobOffer>> GetByRecruiterIdAsync(Guid recruiterId, CancellationToken cancellationToken = default);
}