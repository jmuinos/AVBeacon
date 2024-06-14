using AvBeacon.Domain._Core.Primitives;
using AvBeacon.Domain.Enumerations;

namespace AvBeacon.Domain.Entities;

public sealed class JobApplication : Entity
{
    private JobApplication(Guid applicantId, Guid jobOfferId)
        : base(Guid.NewGuid())
    {
        ApplicantId = applicantId;
        JobOfferId = jobOfferId;
        State = JobApplicationState.Sent;
    }

    public JobApplicationState State { get; set; }

    public Guid ApplicantId { get; init; }
    public Applicant Applicant { get; init; } = null!;
    public Guid JobOfferId { get; init; }
    public JobOffer JobOffer { get; init; } = null!;

    public static JobApplication Create(Guid applicantId, Guid jobOfferId)
    {
        return new JobApplication(applicantId, jobOfferId);
    }
}