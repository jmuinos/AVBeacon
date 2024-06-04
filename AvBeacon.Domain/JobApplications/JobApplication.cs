using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.JobApplications;

/// <summary>Representa una aplicación de un candidato a una oferta de trabajo.</summary>
public sealed class JobApplication(Guid id, Guid applicantId, Guid jobOfferId, JobApplicationState state)
    : Entity(id)
{
    public Guid ApplicantId { get; private set; } = applicantId;
    public Guid JobOfferId { get; private set; } = jobOfferId;
    public JobApplicationState State { get; private set; } = state;
}