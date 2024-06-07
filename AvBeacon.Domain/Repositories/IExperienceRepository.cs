using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IExperienceRepository : IGenericRepository<Experience>
{
    Task<List<Experience>> SearchByTitleAsync(string titleText, CancellationToken cancellationToken = default);
}