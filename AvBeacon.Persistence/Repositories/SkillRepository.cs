using AvBeacon.Domain.Skills;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Persistence.Repositories;

public class SkillRepository(ApplicationDbContext context) : GenericRepository<Skill>(context), ISkillRepository
{
    public async Task<List<Skill>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default)
    {
        return await DbSet
                    .Where(s => EF.Functions.Like(s.Name, $"%{nameText}%"))
                    .ToListAsync(cancellationToken);
    }
}