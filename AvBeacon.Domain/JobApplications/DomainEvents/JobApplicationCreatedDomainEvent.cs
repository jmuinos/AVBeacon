using AvBeacon.Domain.Core.Events;

namespace AvBeacon.Domain.JobApplications.DomainEvents;

/// <summary>
///     Represents the event that is raised when a job application is sent.
/// </summary>
public sealed class JobApplicationCreatedDomainEvent : IDomainEvent
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="JobApplicationCreatedDomainEvent" /> class.
    /// </summary>
    /// <param name="jobApplication"> The jobApplication. </param>
    internal JobApplicationCreatedDomainEvent(JobApplication jobApplication)
    {
        JobApplication = jobApplication;
    }

    /// <summary>
    ///     Gets the invitation.
    /// </summary>
    public JobApplication JobApplication { get; }
}