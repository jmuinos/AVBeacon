using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Shared;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class ApplicantRepository(IDbContext context)
    : BaseRepository<Applicant>(context), IApplicantRepository
{
    public async Task<Maybe<Applicant>> GetByEmailAsync(Email email)
    {
        var applicant = await Context.Set<Applicant>()
                                     .FirstOrDefaultAsync(a => a.Email == email);
        return Maybe<Applicant>.From(applicant!);
    }

    public async Task<List<Applicant>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Applicant>()
                            .Where(a => EF.Functions.Like(a.FirstName, $"%{name}%") ||
                                        EF.Functions.Like(a.LastName, $"%{name}%"))
                            .ToListAsync(cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(Email email)
    {
        return !await Context.Set<Applicant>()
                             .AnyAsync(a => a.Email == email);
    }
}