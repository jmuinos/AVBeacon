using AvBeacon.Domain._Core.Abstractions;

namespace AvBeacon.Domain.Users.Recruiters.JobOffers;

public interface IJobOfferRepository : IBaseRepository<JobOffer>
{
    Task<List<JobOffer>> GetByRecruiterIdAsync(Guid recruiterId, CancellationToken cancellationToken = default);
}