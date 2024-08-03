using AvBeacon.Domain._Core.Abstractions;

namespace AvBeacon.Domain.Users.Applicants.Educations;

public interface IEducationRepository : IBaseRepository<Education>
{
    Task<List<Education>> GetByTitleAsync(string description, CancellationToken cancellationToken = default);
    Task<List<Education>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
}