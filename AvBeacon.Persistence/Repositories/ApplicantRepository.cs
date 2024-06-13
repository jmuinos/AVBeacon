using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

/// <remarks>
///     Se le pasa directamente el context para poder usar el DbSet de ApplicantSkills. Esto se hace por el hecho de
///     que ApplicantSkills es una tabla intermedia y, a pesar de haber creado una clase que la representa
///     <see cref="ApplicantSkill" />
/// </remarks>
internal sealed class ApplicantRepository(AvBeaconDbContext context)
    : GenericRepository<Applicant>(context), IApplicantRepository
{
    public async Task<List<Skill>> GetSkillsByApplicantId(Guid applicantId)
    {
        return await context.ApplicantSkills
                            .Where(aS => aS.ApplicantId == applicantId)
                            .Select(aS => aS.Skill)
                            .ToListAsync();
    }

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