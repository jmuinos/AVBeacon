using AvBeacon.Domain.Core.Primitives.Maybe;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Repositories;

/// <summary> Represents the user repository interface. </summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<Maybe<User>> GetByEmailAsync(Email email);
    Task<List<User>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUniqueAsync(Email email);
}