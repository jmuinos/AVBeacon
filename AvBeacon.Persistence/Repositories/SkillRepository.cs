using AvBeacon.Domain.Skills;

namespace AvBeacon.Persistence.Repositories;

public class SkillRepository(ApplicationDbContext context)
    : GenericRepository<Skill>(context), ISkillRepository
{
    // TODO
    public Task<Skill?> GetAllBySimilarTitleAsync<T>(string title, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}