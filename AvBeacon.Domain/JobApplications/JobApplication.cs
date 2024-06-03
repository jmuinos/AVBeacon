using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain.JobApplications;

/// <summary>Representa una aplicación de un candidato a una oferta de trabajo.</summary>
public sealed class JobApplication : Entity
{
    public Guid CandidateId { get; private set; }
    public Guid JobOfferId { get; private set; }
    public JobApplicationStateEnum State { get; set; }

    #region Constructors

    public JobApplication(Guid id, Guid candidateId, Guid jobOfferId, JobApplicationStateEnum state)
        : base(id)
    {
        CandidateId = candidateId;
        JobOfferId = jobOfferId;
        State = state;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="JobApplication" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public JobApplication() { }

    #endregion
}