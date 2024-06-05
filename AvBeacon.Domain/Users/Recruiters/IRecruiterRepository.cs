using AvBeacon.Domain._Core;

namespace AvBeacon.Domain.Users.Recruiters;

public interface IRecruiterRepository : IGenericRepository<Recruiter>
{
    Task<Recruiter?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText, CancellationToken cancellationToken = default);

    Task<Recruiter?> GetAllByEmailAsync<T>(string email, CancellationToken cancellationToken = default);
}