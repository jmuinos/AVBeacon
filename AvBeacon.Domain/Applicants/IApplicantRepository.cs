using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.Applicants;

public interface IApplicantRepository : IGenericRepository<Applicant>
{
    Task<Applicant?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default);
}