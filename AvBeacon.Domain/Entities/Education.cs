using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain.Enumerations;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Education : Entity
{
    public Education(EducationType educationType, Title title, Description description, Guid applicantId)
        : base(Guid.NewGuid())
    {
        EducationType = educationType;
        Title = title;
        Description = description;
        ApplicantId = applicantId;
    }

    public EducationType EducationType { get; init; }
    public Title Title { get; set; }
    public Description Description { get; set; }

    public Guid ApplicantId { get; init; }
    public Applicant Applicant { get; init; } = null!;

    public static Education Create(EducationType educationType, Title title, Description description, Guid applicantId)
    {
        return new Education(educationType, title, description, applicantId);
    }
}