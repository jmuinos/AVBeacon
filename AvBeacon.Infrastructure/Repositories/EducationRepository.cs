using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class EducationRepository(ApplicationDbContext context)
    : GenericRepository<Education>(context), IEducationRepository
{
    public async Task<List<Education>> SearchByDescriptionAsync(string descriptionText,
        CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(e => EF.Functions.Like(e.Description, $"%{descriptionText}%"))
                    .ToListAsync(cancellationToken);
    }
}