using AvBeacon.Domain._Core.Abstractions;

namespace AvBeacon.Domain.Users.Applicants.Experiences;

public interface IExperienceRepository : IBaseRepository<Experience>
{
    Task<List<Experience>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
}