using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<List<User>> SearchByNameAsync(string name, CancellationToken cancellationToken = default);
}