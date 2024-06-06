using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.Experiences;

public interface IExperienceRepository : IGenericRepository<Experience>
{
    Task<List<Experience>> SearchByTitleAsync(string titleText, CancellationToken cancellationToken = default);
}