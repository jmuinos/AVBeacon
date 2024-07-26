using AvBeacon.Domain.Applicants;

namespace AvBeacon.Domain.Repositories
{
    public interface IExperienceRepository : IBaseRepository<Experience>
    {
        Task<List<Experience>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
    }
}