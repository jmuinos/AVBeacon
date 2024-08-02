using AvBeacon.Domain.Common;

namespace AvBeacon.Domain.Applicants;

public interface IEducationRepository : IBaseRepository<Education>
{
    Task<List<Education>> GetByTitleAsync(string description, CancellationToken cancellationToken = default);
    Task<List<Education>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
}