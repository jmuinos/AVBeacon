using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class ExperienceRepository(IDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
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