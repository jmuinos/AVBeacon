using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Shared;

namespace AvBeacon.Domain.Users.Applicants.Skills;

public sealed class Skill : Entity, IAuditableEntity, ISoftDeletableEntity
{
    public Skill(Title title) : base(Guid.NewGuid())
    {
        Title = title;
    }

    private Skill() { }

    public Title Title { get; private set; } = null!;

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; init; }

    /// <inheritdoc />
    public bool Deleted { get; init; }
}