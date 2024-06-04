using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.JobApplications;

/// <summary>Representa una aplicación de un candidato a una oferta de trabajo.</summary>
public sealed class JobApplication : Entity
{
    public Guid CandidateId { get; private set; }
    public Guid JobOfferId { get; private set; }
    public JobApplicationState State { get; set; }

    #region Constructors

    public JobApplication(Guid id, Guid candidateId, Guid jobOfferId, JobApplicationState state)
        : base(id)
    {
        CandidateId = candidateId;
        JobOfferId = jobOfferId;
        State = state;
    }


    public JobApplication() { }

    #endregion
}