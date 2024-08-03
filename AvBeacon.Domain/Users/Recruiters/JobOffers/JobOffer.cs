using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Guards;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Shared;

namespace AvBeacon.Domain.Users.Recruiters.JobOffers;

/// <summary>
///     Representa una oferta de trabajo.
/// </summary>
public sealed class JobOffer : Entity, IAuditableEntity, ISoftDeletableEntity
{
    internal JobOffer(Recruiter recruiter, Title title, Description description)
        : base(Guid.NewGuid())
    {
        Ensure.NotNull(recruiter, "The recruiter is required.", nameof(recruiter));
        Ensure.NotNull(title, "The title is required.", nameof(title));
        Ensure.NotNull(description, "The description is required.", nameof(description));

        RecruiterId = recruiter.Id;
        Title       = title;
        Description = description;
    }

    public Title Title { get; set; }
    public Description Description { get; set; }
    public Guid RecruiterId { get; init; }

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; init; }

    /// <inheritdoc />
    public bool Deleted { get; init; }

    /// <summary>
    ///     Changes the job offer title and returns true if a change has occurred.
    /// </summary>
    /// <param name="title"> The new job offer title. </param>
    /// <returns> True if the job offer title has changed, otherwise false. </returns>
    public bool ChangeTitle(Title title)
    {
        string previousTitle = Title;

        if (title == Title)
            return false;

        Title = title;

        return true;
    }

    /// <summary>
    ///     Changes the job offer description and returns true if a change has occurred.
    /// </summary>
    /// <param name="description"> The new description. </param>
    /// <returns> True if the job offer description has changed, otherwise false. </returns>
    public bool ChangeDescription(Description description)
    {
        string previousDescription = Description;

        if (description == Description)
            return false;

        Description = description;

        return true;
    }
}