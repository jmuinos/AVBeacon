using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Shared;

namespace AvBeacon.Domain.Users.Applicants.Educations;

public sealed class Education : Entity
{
    internal Education(Applicant applicant, Title title, Description description, EducationType educationType)
        : base(Guid.NewGuid())
    {
        ApplicantId   = applicant.Id;
        Title         = title;
        Description   = description;
        EducationType = educationType;
    }

    public EducationType EducationType { get; private init; }
    public Title Title { get; private set; }
    public Description Description { get; private set; }

    public Guid ApplicantId { get; init; }
}