using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IJobOfferRepository
{
    Task<Maybe<JobOffer>> GetByIdAsync(Guid id);
    void Insert(JobOffer jobOffer);
    void Update(JobOffer jobOffer);
    void Remove(JobOffer jobOffer);
    Task<List<JobOffer>> GetByRecruiterIdAsync(Guid recruiterId, CancellationToken cancellationToken = default);
}