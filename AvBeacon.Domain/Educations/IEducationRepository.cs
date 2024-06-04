using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.Educations;

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<Education?>GetAllByTitle<T>(string titleText, CancellationToken cancellationToken = default);
    Task<Education?>GetAllByCandidateId<T>(Guid candidateId, CancellationToken cancellationToken = default);
}