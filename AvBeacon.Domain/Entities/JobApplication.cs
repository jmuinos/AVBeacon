using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class JobApplication : Entity
{
    public JobApplication(Guid applicantId, Guid jobOfferId)
        : base(Guid.NewGuid())
    {
        ApplicantId = applicantId;
        JobOfferId = jobOfferId;
        State = JobApplicationState.Sent;
    }

    public Guid ApplicantId { get; init; }
    public Guid JobOfferId { get; init; }
    public JobApplicationState State { get; set; }
    public Applicant Applicant { get; init; } = null!;
    public JobOffer JobOffer { get; init; } = null!;
}