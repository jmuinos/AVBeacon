using AvBeacon.Domain.Shared;
using AvBeacon.Domain.Skills;

namespace AvBeacon.Infrastructure.Repositories;

public class SkillRepository(ApplicationDbContext context)
    : GenericRepository<Skill>(context), ISkillRepository
{
    // TODO
    public Task<Skill?> GetAllBySimilarTitleAsync<T>(Title title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}