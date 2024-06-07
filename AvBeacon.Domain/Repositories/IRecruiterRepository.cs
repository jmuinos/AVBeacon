using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IRecruiterRepository : IGenericRepository<Recruiter>
{
    Task<Recruiter?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<Recruiter>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}