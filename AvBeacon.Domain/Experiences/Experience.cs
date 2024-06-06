using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Experiences;

public sealed class Experience(
    Guid id,
    string title,
    string? description,
    string? recruiterName,
    DateTime? start,
    DateTime? end)
    : Entity(id)
{
    public string Title { get; private set; } = title;
    public string? Description { get; private set; } = description;
    public string? RecruiterName { get; private set; } = recruiterName;
    public DateTime? Start { get; private set; } = start;
    public DateTime? End { get; private set; } = end;
    public object? ApplicantId { get; init; }
}