using AvBeacon.Domain.Core.Abstractions.Primitives;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa una aplicación de un candidato a una oferta de trabajo.</summary>
public sealed class JobApplication : Entity
{
    #region Constructors

    public JobApplication(Guid id, Guid candidateId, Guid jobOfferId)
        : base(id)
    {
        CandidateId = candidateId;
        JobOfferId = jobOfferId;
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

    #endregion
}