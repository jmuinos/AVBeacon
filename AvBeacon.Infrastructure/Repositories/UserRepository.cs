using AvBeacon.Domain.Users;

namespace AvBeacon.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context)
    : GenericRepository<User>(context), IUserRepository
{
    // TODO

}