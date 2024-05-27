using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa una oferta de trabajo creada por un usuario reclutador.</summary>
public sealed class Education : Entity
{
    #region Constructors

    public Education(Guid id, EducationType name, string description, DateTime? start, DateTime? end)
        : base(id)
    {
        Name = name;
        Description = description;
        Start = start;
        End = end;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Education" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Education()
    {
    }

    #endregion

    #region Properties

    public required EducationType Name { get; set; }
    public required string Description { get; set; }
    public required DateTime? Start { get; set; }
    public required DateTime? End { get; set; }

    #endregion
}