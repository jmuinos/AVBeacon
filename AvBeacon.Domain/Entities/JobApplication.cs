using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain._Core.Enumerables;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa una aplicación de un candidato a una oferta de trabajo.</summary>
public sealed class JobApplication : Entity
{
    #region Constructors

    public JobApplication(Guid id, Guid candidateId, Guid jobOfferId, JobApplicationState state)
        : base(id)
    {
        CandidateId = candidateId;
        JobOfferId = jobOfferId;
        JobApplicationState = state;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="JobApplication" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public JobApplication()
    {
    }

    #endregion

    #region Properties

    public Guid CandidateId { get; private set; }
    public Guid JobOfferId { get; private set; }

    public JobApplicationState JobApplicationState { get; set; }

    #endregion
}