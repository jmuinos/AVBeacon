using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Applicants;

namespace AvBeacon.Domain.JobApplications;

public sealed class JobApplication(Guid id, Guid applicantId, Guid jobOfferId, JobApplicationState state)
    : Entity(id)
{
    public Guid ApplicantId { get; private set; } = applicantId;
    public Guid JobOfferId { get; private set; } = jobOfferId;
    public JobApplicationState State { get; private set; } = state;

    // Propiedad de navegación a Applicant
    public Applicant Applicant { get; init; } = null!;
}