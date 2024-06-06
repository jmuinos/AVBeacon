using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Educations;

public sealed class Education(
    Guid id,
    EducationType educationType,
    string description,
    DateTime? start,
    DateTime? end)
    : Entity(id)
{
    public EducationType EducationType { get; private set; } = educationType;
    public string Description { get; private set; } = description;
    public DateTime? Start { get; private set; } = start;
    public DateTime? End { get; private set; } = end;

    // Propiedad de navegación a Applicant
    public object? ApplicantId { get; init; }
}