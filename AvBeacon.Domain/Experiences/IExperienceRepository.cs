using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.Experiences;

public interface IExperienceRepository : IGenericRepository<Experience>
{
    Task<Experience?> GetAllBySimilarTitle<T>(Title title, CancellationToken cancellationToken = default);
    Task<Experience?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default);
}