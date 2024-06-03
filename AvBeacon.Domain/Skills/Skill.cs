using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Shared;
using AvBeacon.Domain.Users;

namespace AvBeacon.Domain.Skills;

public sealed class Skill : Entity
{
    #region Properties

    public required Title Title { get; set; }

    #endregion

    #region Constructors

    public Skill(Guid id, Title title) : base(id) { Title = title; }

    /// <summary>Inicializa una nueva instancia de la clase.<see cref="User" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    public Skill() { }

    #endregion
}