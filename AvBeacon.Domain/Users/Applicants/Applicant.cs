using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants.Educations;
using AvBeacon.Domain.Users.Applicants.Experiences;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Domain.Users.Applicants;

public sealed class Applicant : User
{

    internal Applicant(FirstName firstName, LastName lastName, Email email, string passwordHash)
        : base(firstName, lastName, email, passwordHash, UserType.Applicant) { }

    /// <summary>
    ///     Creates a new job application.
    /// </summary>
    /// <param name="jobOffer"> The job offer. </param>
    /// <returns> The newly created job application. </returns>
    public JobApplication CreateJobApplication(JobOffer jobOffer)
    {
        return new JobApplication(this, jobOffer);
    }

    public Education CreateEducation(Title title, Description description, EducationType educationType)
    {
        return new Education(this, title, description, educationType);
    }

    public Experience CreateExperience(Title title, Description description, DateTime? start,
        DateTime? end)
    {
        return new Experience(this, title, description, start, end);
    }
}