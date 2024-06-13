using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Domain.Repositories;

public interface ISkillRepository
{
    Task<Maybe<Skill>> GetByIdAsync(Guid id);
    void Insert(Skill skill);
    void Update(Skill skill);
    void Remove(Skill skill);
}