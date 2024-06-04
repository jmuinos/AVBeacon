using AvBeacon.Domain._Core.Interfaces;

namespace AvBeacon.Domain.Users;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default);

    Task<User?> GetAllByEmailAsync<T>(Email email, CancellationToken cancellationToken = default);
}