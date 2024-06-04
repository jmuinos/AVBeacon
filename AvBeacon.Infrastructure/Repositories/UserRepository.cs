using AvBeacon.Domain.Users;

namespace AvBeacon.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context)
    : GenericRepository<User>(context), IUserRepository
{
    // TODO
    public Task<User?> GetAllBySimilarFirstNameOrLastNameAsync<T>(string nameText,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetAllByEmailAsync<T>(Email email, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}