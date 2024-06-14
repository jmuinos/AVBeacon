using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class RecruiterRepository(IDbContext context)
    : GenericRepository<Recruiter>(context), IRecruiterRepository
{
    public async Task<Maybe<Recruiter>> GetByEmailAsync(Email email)
    {
        var recruiter = await Context.Set<Recruiter>()
            .FirstOrDefaultAsync(r => r.Email == email);
        return Maybe<Recruiter>.From(recruiter!);
    }

    public async Task<List<Recruiter>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Recruiter>()
            .Where(r => EF.Functions.Like(r.FirstName, $"%{name}%") ||
                        EF.Functions.Like(r.LastName, $"%{name}%"))
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(Email email)
    {
        return !await Context.Set<Recruiter>()
            .AnyAsync(r => r.Email == email);
    }
}