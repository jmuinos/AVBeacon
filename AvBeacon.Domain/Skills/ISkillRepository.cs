using AvBeacon.Domain._Core.Interfaces;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.Skills;

public interface ISkillRepository : IGenericRepository<Skill>
{
    Task<Skill?> GetAllBySimilarTitleAsync<T>(Title title, CancellationToken cancellationToken = default);
}