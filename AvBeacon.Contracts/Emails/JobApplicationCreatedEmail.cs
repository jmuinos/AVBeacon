namespace AvBeacon.Contracts.Emails;

/// <summary>
/// Represents the invitation accepted email.
/// </summary>
public sealed class JobApplicationCreatedEmail
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JobApplicationProcessedEmail"/> class.
    /// </summary>
    /// <param name="emailTo">The email receiver.</param>
    /// <param name="name">The name.</param>
    /// <param name="jobOfferTitle">The job offer title.</param>
    /// <param name="recruiterName">The event name.</param>
    public JobApplicationCreatedEmail(string emailTo, string name, string jobOfferTitle, string recruiterName)
    {
        EmailTo = emailTo;
        Name = name;
        JobOfferTitle = jobOfferTitle;
        RecruiterName = recruiterName;
    }

    /// <summary>
    /// Gets the email receiver.
    /// </summary>
    public string EmailTo { get; }

    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the job offer title.
    /// </summary>
    public string JobOfferTitle { get; set; }

    /// <summary>
    /// Gets the job offer recruiter name.
    /// </summary>
    public string RecruiterName { get; set; }
}