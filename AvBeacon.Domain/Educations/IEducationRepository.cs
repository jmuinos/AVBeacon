using AvBeacon.Domain._Core;

namespace AvBeacon.Domain.Educations;

public interface IEducationRepository : IGenericRepository<Education>
{
    Task<Education?> GetAllBySimilarTitle<T>(string title, CancellationToken cancellationToken = default);
    Task<Education?> GetAllByApplicantId<T>(Guid applicantId, CancellationToken cancellationToken = default);
}