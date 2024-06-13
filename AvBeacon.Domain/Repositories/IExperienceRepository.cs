using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IExperienceRepository
{
    Task<List<Experience>> GetByApplicantIdAsync(Guid applicantId, CancellationToken cancellationToken = default);
    Task<Maybe<Experience>> GetByIdAsync(Guid id);
    void Insert(Experience experience);
    void Update(Experience experience);
    void Remove(Experience experience);
}