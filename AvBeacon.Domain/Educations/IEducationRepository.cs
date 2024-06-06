using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.Educations;

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<List<Education>> SearchByDescriptionAsync(string descriptionText,
        CancellationToken cancellationToken = default);
}