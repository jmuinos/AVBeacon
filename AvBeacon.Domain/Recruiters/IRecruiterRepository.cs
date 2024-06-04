using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.Recruiters;

public interface IRecruiterRepository : IGenericRepository<Recruiter>
{
    Task<Recruiter?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default);
}