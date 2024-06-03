using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context)
    : GenericRepository<User>(context), IUserRepository;