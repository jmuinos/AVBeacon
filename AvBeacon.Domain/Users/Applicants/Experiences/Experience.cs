using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Shared;

namespace AvBeacon.Domain.Users.Applicants.Experiences;

public sealed class Experience : Entity, IAuditableEntity, ISoftDeletableEntity
{
    internal Experience(Applicant applicant, Title title, Description description, DateTime? start, DateTime? end)
        : base(Guid.NewGuid())
    {
        ApplicantId = applicant.Id;
        Title       = title;
        Description = description;
        Start       = start;
        End         = end;
    }

    private Experience() { }

    public Guid ApplicantId { get; init; }

    public Title Title { get; set; } = null!;
    public Description Description { get; set; } = null!;
    public DateTime? Start { get; init; }
    public DateTime? End { get; set; }

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; init; }

    /// <inheritdoc />
    public bool Deleted { get; init; }
}