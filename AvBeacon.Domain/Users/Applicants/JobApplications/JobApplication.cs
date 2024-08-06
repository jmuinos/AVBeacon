using AvBeacon.Domain._Core.Abstractions;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Guards;
using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Users.Recruiters.JobOffers;

namespace AvBeacon.Domain.Users.Applicants.JobApplications;

public sealed class JobApplication : Entity, IAuditableEntity, ISoftDeletableEntity
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

    private JobApplication() { }

    public Guid ApplicantId { get; private init; }
    public Guid JobOfferId { get; private init; }
    
    public JobApplicationState State { get; private set; } = null!;

    /// <inheritdoc />
    public DateTime CreatedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? ModifiedOnUtc { get; init; }

    /// <inheritdoc />
    public DateTime? DeletedOnUtc { get; init; }

    /// <inheritdoc />
    public bool Deleted { get; init; }

    /// <summary>
    ///     Marks the job application as processed and returns the respective result.
    /// </summary>
    /// <returns> The success result if the job application was not previously marked as processed, otherwise a failure result. </returns>
    public Result ChangeState(JobApplicationState state)
    {
        if (State.Equals(JobApplicationState.Rejected) || State.Equals(JobApplicationState.Accepted))
            return Result.Failure(DomainErrors.JobApplications.AlreadyProcessed);

        State = state;

        return Result.Success();
    }
}