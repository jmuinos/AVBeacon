using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.Experiences;

public interface IExperienceRepository : IGenericRepository<Experience>
{
    Task<Experience?>GetAllByTitle<T>(string titleText, CancellationToken cancellationToken = default);
    Task<Experience?>GetAllByCandidateId<T>(Guid candidateId, CancellationToken cancellationToken = default);
    Task<Experience?>GetAllByDateRangeDaysPassed<T>(Guid candidateId, CancellationToken cancellationToken = default);
}