using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobApplications.DomainEvents;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Applicants;

public sealed class Applicant : User
{
    private Applicant(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash, UserType.Applicant) { }

    public static Applicant Create(FirstName firstName, LastName lastName, Email email, string passwordHash)
    {
        return new Applicant(firstName, lastName, email, passwordHash);
    }

    /// <summary>
    ///     Creates a new job application.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <returns> The newly created personal event. </returns>
    public JobApplication CreateJobApplication(JobOffer jobOffer)
    {
        var jobApplication = new JobApplication(this, jobOffer);
        AddDomainEvent(new JobApplicationCreatedDomainEvent(jobApplication));

        return jobApplication;
    }
}