using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Users.Applicants.Experiences;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class ExperienceRepository(IDbContext context)
    : BaseRepository<Experience>(context), IExperienceRepository
{
    public async Task<List<Experience>> GetByApplicantIdAsync(Guid applicantId,
        CancellationToken cancellationToken)
    {
        return await Context.Set<Experience>()
                            .Where(ja => ja.ApplicantId == applicantId)
                            .ToListAsync(cancellationToken);
    }

    public async Task<List<Experience>> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Experience>()
                            .Where(e => EF.Functions.Like(e.Title.Value, $"%{title}%"))
                            .ToListAsync(cancellationToken);
    }
}