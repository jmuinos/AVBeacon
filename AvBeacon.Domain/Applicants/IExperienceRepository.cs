using AvBeacon.Domain.Common;

namespace AvBeacon.Domain.Applicants;

public interface IExperienceRepository : IBaseRepository<Experience>
{
    Task<List<Experience>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
}