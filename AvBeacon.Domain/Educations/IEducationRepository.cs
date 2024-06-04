using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.Educations;

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<Education?> GetAllBySimilarTitle<T>(Title title, CancellationToken cancellationToken = default);
    Task<Education?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default);
}