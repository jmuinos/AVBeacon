using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobOffers.DomainEvents;

/// <summary>
///     Represents the event that is raised when a job offer is cancelled.
/// </summary>
public sealed class JobOfferCancelledDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobOfferCancelledDomainEvent" /> class.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    internal JobOfferCancelledDomainEvent(JobOffer jobOffer)
    {
        JobOffer = jobOffer;
    }

    /// <summary>
    ///     Gets the job offer.
    /// </summary>
    public JobOffer JobOffer { get; }
}