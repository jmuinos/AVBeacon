using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.Core.ValueObjects;

namespace AvBeacon.Domain.Entities;

public sealed class Skill : Entity
{
    #region Properties

    public required Name Name { get; set; }

    #endregion

    #region Constructors

    public Skill(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    /// <summary>Inicializa una nueva instancia de la clase.<see cref="User" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Skill()
    {
    }

    #endregion
}