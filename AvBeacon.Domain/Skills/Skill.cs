using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Skills;

public sealed class Skill(Guid id, string name)
    : Entity(id)
{
    public string Name { get; private set; } = name;
    public object? ApplicantId { get; init; }
}