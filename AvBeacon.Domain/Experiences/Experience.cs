using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Shared;

namespace AvBeacon.Domain.Experiences;

/// <summary>Representa una experiencia profesional de un candidato.</summary>
public sealed class Experience(
    Guid id,
    Title title,
    Description? description,
    Name? recruiterName,
    DateTime? start,
    DateTime? end)
    : Entity(id)
{
    public Title Title { get; private set; } = title;
    public Description? Description { get; private set; } = description;
    public Name? RecruiterName { get; private set; } = recruiterName;
    public DateTime? Start { get; private set; } = start;
    public DateTime? End { get; private set; } = end;
}