using AvBeacon.Domain.Educations;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

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