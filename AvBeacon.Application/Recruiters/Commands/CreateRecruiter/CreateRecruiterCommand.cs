using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Recruiters.Commands.CreateRecruiter;

/// <summary>Representa el comando para crear un reclutador.</summary>
/// <param name="Email">El correo electrónico del reclutador.</param>
/// <param name="FirstName">El nombre del reclutador.</param>
/// <param name="LastName">El apellido del reclutador.</param>
/// <param name="Password">La contraseña del reclutador.</param>
public sealed record CreateRecruiterCommand(
    string Email,
    string FirstName,
    string LastName,
    string Password) : ICommand<Result<Guid>>;