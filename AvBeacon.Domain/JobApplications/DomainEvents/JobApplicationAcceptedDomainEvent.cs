using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobApplications.DomainEvents;

/// <summary>
///     Represents the event that is raised when a job application is accepted.
/// </summary>
public sealed class JobApplicationAcceptedDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobApplicationAcceptedDomainEvent" /> class.
    /// </summary>
    /// <param name="jobApplication"> The jobApplication. </param>
    internal JobApplicationAcceptedDomainEvent(JobApplication jobApplication)
    {
        JobApplication = jobApplication;
    }

    /// <summary>
    ///     Gets the job application.
    /// </summary>
    public JobApplication JobApplication { get; }
}