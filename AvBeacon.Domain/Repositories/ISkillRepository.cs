using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface ISkillRepository : IGenericRepository<Skill>
{
    Task<List<Skill>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}