using AvBeacon.Domain.Core.Interfaces.Repositories;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context)
    : GenericRepository<User>(context), IUserRepository;