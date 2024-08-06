using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Shared;

namespace AvBeacon.Domain.Users.Applicants.Educations;

public sealed class Education : Entity, IAuditableEntity, ISoftDeletableEntity
{
    internal Education(Applicant applicant, Title title, Description description, EducationType educationType)
        : base(Guid.NewGuid())
    {
        ApplicantId   = applicant.Id;
        Title         = title;
        Description   = description;
        EducationType = educationType;
    }

    private Education() { }

    public Guid ApplicantId { get; init; }

    public EducationType EducationType { get; private init; } = null!;
    public Title Title { get; private set; } = null!;
    public Description Description { get; private set; } = null!;

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; init; }

    /// <inheritdoc />
    public bool Deleted { get; init; }
}