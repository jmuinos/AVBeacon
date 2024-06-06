using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.Recruiters;

public interface IRecruiterRepository : IGenericRepository<Recruiter>
{
    Task<Recruiter?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<Recruiter>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}