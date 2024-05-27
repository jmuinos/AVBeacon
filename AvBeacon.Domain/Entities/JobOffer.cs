using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa una oferta de trabajo creada por un usuario reclutador.</summary>
public sealed class JobOffer : Entity
{
    #region Constructors

    public JobOffer(Guid id, Guid recruiterId, Name title, string description)
        : base(id)
    {
        RecruiterId = recruiterId;
        Title = title;
        Description = description;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="JobOffer" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public JobOffer()
    {
    }

    #endregion

    #region Properties

    public Guid RecruiterId { get; init; }
    public required Name Title { get; set; }
    public required string Description { get; set; }

    #endregion
}