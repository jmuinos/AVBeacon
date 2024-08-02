using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobOffers.DomainEvents;

/// <summary>
///     Represents the event that is raised when the title of a job offer is changed.
/// </summary>
public sealed class JobOfferTitleChangedDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobOfferTitleChangedDomainEvent" /> class.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <param name="previousTitle"> The previous title. </param>
    internal JobOfferTitleChangedDomainEvent(JobOffer jobOffer, string previousTitle)
    {
        JobOffer      = jobOffer;
        PreviousTitle = previousTitle;
    }

    /// <summary>
    ///     Gets the job offer.
    /// </summary>
    public JobOffer JobOffer { get; }

    /// <summary>
    ///     Gets the previous title.
    /// </summary>
    public string PreviousTitle { get; }
}