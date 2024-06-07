using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Education : Entity
{
    public Education(EducationType educationType, string description, DateTime? start, DateTime? end, Guid applicantId)
        : base(Guid.NewGuid())
    {
        EducationType = educationType;
        Description = description;
        Start = start;
        End = end;
        ApplicantId = applicantId;
    }

//TODO Hacer método Create para ocultar constructor con protected
    public EducationType EducationType { get; set; }
    public string Description { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }
    public Guid ApplicantId { get; set; }

    public Applicant Applicant { get; init; } = null!;
}