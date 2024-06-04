using AvBeacon.Domain._Core.Abstractions.Primitives;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Recruiters;

namespace AvBeacon.Domain.Users;

/// <summary>Clase base que representa un usuario.</summary>
/// <remarks>
///     De esta clase derivan entidades que representan tipos de usuario,
///     como por ejemplo <see cref="Applicant" /> o <see cref="Recruiter" />
/// </remarks>
public abstract class User(Guid id, Email email, FirstName firstName, LastName lastName)
    : Entity(id)
{
    public Email Email { get; init; } = email;
    public FirstName FirstName { get; init; } = firstName;
    public LastName LastName { get; init; } = lastName;
}