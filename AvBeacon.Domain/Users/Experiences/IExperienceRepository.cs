using AvBeacon.Domain._Core;

namespace AvBeacon.Domain.Users.Experiences;

public interface IExperienceRepository : IGenericRepository<Experience>
{
    Task<Experience?> GetAllBySimilarTitle<T>(string title, CancellationToken cancellationToken = default);
    Task<Experience?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default);
}