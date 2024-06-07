using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context)
    : GenericRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
    }

    public async Task<List<User>> SearchByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(a => EF.Functions.Like(a.FirstName, $"%{name}%") ||
                                EF.Functions.Like(a.LastName, $"%{name}%"))
                    .ToListAsync(cancellationToken);
    }
}