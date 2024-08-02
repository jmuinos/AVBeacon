using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Domain.Applicants;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

internal sealed class EducationRepository(IDbContext context)
    : BaseRepository<Education>(context), IEducationRepository
{
    public async Task<List<Education>> GetByApplicantIdAsync(
        Guid applicantId, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Education>()
                            .Where(ja => ja.ApplicantId == applicantId)
                            .ToListAsync(cancellationToken);
    }

    public async Task<List<Education>> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await Context.Set<Education>()
                            .Where(e => EF.Functions.Like(e.Title.Value, $"%{title}%"))
                            .ToListAsync(cancellationToken);
    }
}