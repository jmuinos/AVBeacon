using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Shared;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Educations;

/// <summary>Representa una oferta de trabajo creada por un usuario reclutador.</summary>
public sealed class Education(Guid id, EducationType name, Description description, DateTime? start, DateTime? end)
    : Entity(id)
{
    public EducationType Name { get; private set; } = name;
    public Description Description { get; private set; } = description;
    public DateTime? Start { get; private set; } = start;
    public DateTime? End { get; private set; } = end;
}