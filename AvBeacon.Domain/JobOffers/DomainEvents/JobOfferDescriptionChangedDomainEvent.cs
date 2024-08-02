using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobOffers.DomainEvents;

/// <summary>
///     Represents the event that is raised when the description of a job offer is changed.
/// </summary>
public sealed class JobOfferDescriptionChangedDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobOfferTitleChangedDomainEvent" /> class.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <param name="previousDescription"> The previous title. </param>
    internal JobOfferDescriptionChangedDomainEvent(JobOffer jobOffer, string previousDescription)
    {
        JobOffer            = jobOffer;
        PreviousDescription = previousDescription;
    }

    /// <summary>
    ///     Gets the job offer.
    /// </summary>
    public JobOffer JobOffer { get; }

    /// <summary>
    ///     Gets the previous description.
    /// </summary>
    public string PreviousDescription { get; }
}