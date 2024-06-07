using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Infrastructure.Repositories;

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository
{
    public async Task<List<Skill>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(s => EF.Functions.Like(s.Title, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }
}