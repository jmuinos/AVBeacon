using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Domain.Users.Recruiters;

public sealed class Recruiter : User
{
    internal Recruiter(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash, UserType.Recruiter) { }

    /// <summary>
    ///     Creates a new job offer.
    /// </summary>
    /// <param name="title"> The job offer title. </param>
    /// <param name="description"> The job offer description. </param>
    /// <returns> The newly created job offer. </returns>
    public JobOffer CreateJobOffer(Title title, Description description)
    {
        return new JobOffer(this, title, description);
    }
}