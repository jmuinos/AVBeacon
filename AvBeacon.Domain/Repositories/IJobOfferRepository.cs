using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IJobOfferRepository : IBaseRepository<JobOffer>
{
    Task<List<JobOffer>> GetByRecruiterIdAsync(Guid recruiterId, CancellationToken cancellationToken = default);
}