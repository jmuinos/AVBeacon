using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<List<Education>> SearchByDescriptionAsync(string descriptionText,
        CancellationToken cancellationToken = default);
}