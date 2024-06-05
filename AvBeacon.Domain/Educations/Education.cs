using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Applicants;

namespace AvBeacon.Domain.Educations;

public sealed class Education(Guid id, EducationType educationType, string description, DateTime? start, DateTime? end)
    : Entity(id)
{
    public EducationType EducationType { get; private set; } = educationType;
    public string Description { get; private set; } = description;
    public DateTime? Start { get; private set; } = start;
    public DateTime? End { get; private set; } = end;
}