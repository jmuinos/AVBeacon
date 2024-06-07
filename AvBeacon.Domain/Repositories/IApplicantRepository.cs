using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}