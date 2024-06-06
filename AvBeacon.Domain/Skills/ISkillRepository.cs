using AvBeacon.Domain._Interfaces;

namespace AvBeacon.Domain.Skills;

public interface ISkillRepository : IGenericRepository<Skill>
{
    Task<List<Skill>> SearchByNameAsync(string nameText, CancellationToken cancellationToken = default);
}