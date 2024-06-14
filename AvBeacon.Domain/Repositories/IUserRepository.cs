using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Repositories;

/// <summary> Represents the user repository interface. </summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<Maybe<Applicant>> GetByEmailAsync(Email email);
    Task<List<Applicant>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<bool> IsEmailUniqueAsync(Email email);
}