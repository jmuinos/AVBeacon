using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Abstractions;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Guards;
using AvBeacon.Domain.Core.Primitives;
using AvBeacon.Domain.Core.Primitives.Result;
using AvBeacon.Domain.JobOffers;

namespace AvBeacon.Domain.JobApplications;

public class JobApplication : AggregateRoot, IAuditableEntity, ISoftDeletableEntity
{
    internal JobApplication(Applicant applicant, JobOffer jobOffer)
        : base(Guid.NewGuid())
    {
        Ensure.NotNull(applicant, "The applicant is required.", nameof(applicant));
        Ensure.NotNull(jobOffer, "The job offer is required.", nameof(jobOffer));

        ApplicantId = applicant.Id;
        JobOfferId  = jobOffer.Id;
        State       = JobApplicationState.Sent;
    }

    public JobApplicationState State { get; private set; }

    public Guid ApplicantId { get; private init; }
    public Guid JobOfferId { get; private init; }

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; }

    /// <inheritdoc />
    public bool Deleted { get; }

    /// <summary>
    ///     Marks the event as processed and returns the respective result.
    /// </summary>
    /// <returns> The success result if the event was not previously marked as processed, otherwise a failure result. </returns>
    public Result ChangeState(JobApplicationState state)
    {
        if (State.Equals(JobApplicationState.Rejected) || State.Equals(JobApplicationState.Accepted))
            return Result.Failure(DomainErrors.JobApplications.AlreadyProcessed);

        State = state;

        return Result.Success();
    }
}