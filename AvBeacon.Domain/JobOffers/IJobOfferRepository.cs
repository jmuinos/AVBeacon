using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.JobOffers;

public interface IJobOfferRepository : IGenericRepository<JobOffer>
{
    Task<JobOffer?> GetAllByRecruiterId<T>(Guid applicantId, CancellationToken cancellationToken = default);
    Task<JobOffer?> GetAllBySimilarTitle<T>(Title title, CancellationToken cancellationToken = default);
}