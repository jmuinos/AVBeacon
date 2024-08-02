using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobApplications.DomainEvents;

/// <summary>
///     Represents the event that is raised when a job application is rejected.
/// </summary>
public sealed class JobApplicationRejectedDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobApplicationRejectedDomainEvent" /> class.
    /// </summary>
    /// <param name="jobApplication"> The jobApplication. </param>
    internal JobApplicationRejectedDomainEvent(JobApplication jobApplication)
    {
        JobApplication = jobApplication;
    }

    /// <summary>
    ///     Gets the job application.
    /// </summary>
    public JobApplication JobApplication { get; }
}