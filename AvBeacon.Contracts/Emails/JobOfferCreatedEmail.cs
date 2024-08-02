namespace AvBeacon.Contracts.Emails;

/// <summary>
///     Represents the invitation accepted email.
/// </summary>
public sealed class JobOfferCreatedEmail
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobApplicationProcessedEmail" /> class.
    /// </summary>
    /// <param name="emailTo"> The email receiver. </param>
    /// <param name="name"> The name. </param>
    /// <param name="jobOfferTitle"> The job offer title. </param>
    /// <param name="recruiterName"> The event name. </param>
    public JobOfferCreatedEmail(string emailTo, string name, string jobOfferTitle, string recruiterName)
    {
        EmailTo       = emailTo;
        Name          = name;
        JobOfferTitle = jobOfferTitle;
    }

    /// <summary>
    ///     Gets the email receiver.
    /// </summary>
    public string EmailTo { get; }

    /// <summary>
    ///     Gets the name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Gets the job offer receiver.
    /// </summary>
    public string JobOfferTitle { get; set; }
}