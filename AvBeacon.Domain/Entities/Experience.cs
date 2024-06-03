using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.Core.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary>Representa una experiencia profesional de un candidato.</summary>
public sealed class Experience : Entity
{
    #region Constructors

    public Experience(Guid id, string? description, Name? recruiterName, DateTime? start, DateTime? end)
        : base(id)
    {
        Description = description;
        RecruiterName = recruiterName;
        Start = start;
        End = end;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="Experience" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Experience()
    {
    }

    #endregion

    #region Properties

    public string? Description { get; set; }
    public Name? RecruiterName { get; set; }

    public DateTime? Start { get; set; }
    public DateTime? End { get; set; }

    #endregion
}