using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Core.Primitives.Maybe;
using AvBeacon.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class UserRepository(IDbContext context)
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<Maybe<User>> GetByEmailAsync(Email email)
    {
        var applicant = await Context.Set<User>()
                                     .FirstOrDefaultAsync(a => a.Email == email);
        return Maybe<User>.From(applicant!);
    }

    public async Task<List<User>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await Context.Set<User>()
                            .Where(a => EF.Functions.Like(a.FirstName, $"%{name}%") ||
                                        EF.Functions.Like(a.LastName, $"%{name}%"))
                            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(Email email)
    {
        return !await Context.Set<User>()
                             .AnyAsync(a => a.Email == email);
    }
}