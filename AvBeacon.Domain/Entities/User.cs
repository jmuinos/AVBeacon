using AvBeacon.Domain.Core.Abstractions.Primitives;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Domain.Entities;

/// <summary>Clase base que representa un usuario.</summary>
/// <remarks>
///     De esta clase derivan entidades que representan tipos de usuario,
///     como por ejemplo <see cref="Candidate" /> o <see cref="Recruiter" />
/// </remarks>
public abstract class User : Entity
{
    #region Constructors

    protected User(Guid id, Email email, FirstName firstName, LastName lastName)
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>Inicializa una nueva instancia de la clase <see cref="User" />.</summary>
    /// <remarks>Es requerido por Entity Framework Core.</remarks>
    protected User()
    {
    }

    #endregion

    #region Properties

    public required Email Email { get; init; }
    public required FirstName FirstName { get; init; }
    public required LastName LastName { get; init; }

    #endregion
}