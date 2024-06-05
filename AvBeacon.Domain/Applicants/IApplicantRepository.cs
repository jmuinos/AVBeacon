using AvBeacon.Domain._Core;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Applicants;

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    Task<Applicant?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText, CancellationToken cancellationToken = default);

    Task<Applicant?> GetAllByEmailAsync<T>(string email, CancellationToken cancellationToken = default);
}