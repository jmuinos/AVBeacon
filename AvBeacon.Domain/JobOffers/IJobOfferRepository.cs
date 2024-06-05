using AvBeacon.Domain._Core;

namespace AvBeacon.Domain.JobOffers;

public interface IJobOfferRepository : IGenericRepository<JobOffer>
{
    Task<JobOffer?> GetAllByRecruiterId<T>(Guid applicantId, CancellationToken cancellationToken = default);
    Task<JobOffer?> GetAllBySimilarTitle<T>(string title, CancellationToken cancellationToken = default);
}