using AvBeacon.Domain.Common;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.JobOffers.DomainEvents;

namespace AvBeacon.Domain.Users.Recruiters;

public sealed class Recruiter : User
{
    private Recruiter(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash, UserType.Recruiter) { }

    public ICollection<JobOffer> JobOffers { get; private set; } = new List<JobOffer>();

    public static Recruiter Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Recruiter(firstName, lastName, email, passwordHash);
    }

    /// <summary>
    ///     Creates a new job offer.
    /// </summary>
    /// <param name="title"> The job offer title.</param>
    /// <param name="description"> The job offer description.</param>
    /// <returns> The newly created personal event. </returns>
    public JobOffer CreateJobOffer(Title title, Description description)
    {
        var jobOffer = new JobOffer(this, title, description);
        AddDomainEvent(new JobOfferCreatedDomainEvent(jobOffer));

        return jobOffer;
    }
}