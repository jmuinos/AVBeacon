using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobOffers.DomainEvents;

/// <summary>
///     Represents the event that is raised when a job offer is created.
/// </summary>
public sealed class JobOfferCreatedDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobOfferCreatedDomainEvent" /> class.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    internal JobOfferCreatedDomainEvent(JobOffer jobOffer)
    {
        JobOffer = jobOffer;
    }

    /// <summary>
    ///     Gets the job offer.
    /// </summary>
    public JobOffer JobOffer { get; }
}