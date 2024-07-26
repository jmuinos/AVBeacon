using AvBeacon.Domain.Recruiters;

namespace AvBeacon.Domain.Repositories
{
    public interface IJobOfferRepository : IBaseRepository<JobOffer>
    {
        Task<List<JobOffer>> GetByRecruiterIdAsync(Guid recruiterId, CancellationToken cancellationToken = default);
    }
}