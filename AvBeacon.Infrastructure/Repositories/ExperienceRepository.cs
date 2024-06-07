using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class ExperienceRepository(ApplicationDbContext context)
    : GenericRepository<Experience>(context), IExperienceRepository
{
    public async Task<List<Experience>> SearchByTitleAsync(string titleText,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(e => EF.Functions.Like(e.Title, $"%{titleText}%"))
                    .ToListAsync(cancellationToken);
    }
}