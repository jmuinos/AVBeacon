using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.Skills;

public sealed class Skill(Guid id, Title title) : Entity(id)
{
    public Title Title { get; private set; } = title;
}