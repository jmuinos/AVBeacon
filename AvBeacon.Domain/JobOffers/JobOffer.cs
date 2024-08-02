using AvBeacon.Domain.Common;
using AvBeacon.Domain.Core.Abstractions;
using AvBeacon.Domain.Core.Guards;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers.DomainEvents;
using AvBeacon.Domain.Users.Recruiters;

namespace AvBeacon.Domain.JobOffers;

/// <summary>
///     Representa una oferta de trabajo.
/// </summary>
public sealed class JobOffer : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    internal JobOffer(Recruiter recruiter, Title title, Description description)
        : base(Guid.NewGuid())
    {
        Ensure.NotNull(recruiter, "The recruiter is required.", nameof(recruiter));
        Ensure.NotNull(title, "The name is required.", nameof(title));
        Ensure.NotNull(description, "The description is required.", nameof(description));

        RecruiterId = recruiter.Id;
        Title       = title;
        Description = description;
    }

    public Title Title { get; set; }
    public Description Description { get; set; }
    public Guid RecruiterId { get; init; }
    public Recruiter Recruiter { get; init; } = null!;
    public ICollection<JobApplication> JobApplications { get; private set; } = new List<JobApplication>();

    /// <summary>
    ///     Gets the date and time of the job offer end in UTC format.
    /// </summary>
    public DateTime DateTimeUtc { get; }

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; }

    /// <inheritdoc />
    public bool Deleted { get; }

    /// <summary>
    ///     Changes the job offer title and returns true if a change has occurred.
    /// </summary>
    /// <param name="title"> The new event name. </param>
    /// <returns> True if the events name has changed, otherwise false. </returns>
    public bool ChangeTitle(Title title)
    {
        string previousTitle = Title;

        if (title == Title)
            return false;

        Title = title;
        AddDomainEvent(new JobOfferTitleChangedDomainEvent(this, previousTitle));

        return true;
    }

    /// <summary>
    ///     Changes the job offer title and returns true if a change has occurred.
    /// </summary>
    /// <param name="description"> The new event name. </param>
    /// <returns> True if the events name has changed, otherwise false. </returns>
    public bool ChangeDescription(Description description)
    {
        string previousDescription = Description;

        if (description == Description)
            return false;

        Description = description;
        AddDomainEvent(new JobOfferDescriptionChangedDomainEvent(this, previousDescription));

        return true;
    }
}