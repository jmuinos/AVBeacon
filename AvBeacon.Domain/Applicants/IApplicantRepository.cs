using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.Applicants;

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    Task<Applicant?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<Applicant>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}