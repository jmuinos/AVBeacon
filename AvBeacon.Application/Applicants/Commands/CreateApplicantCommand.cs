using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Applicants.Commands;

/// <summary>Representa el comando para crear un solicitante.</summary>
/// <param name="Email">El correo electrónico del solicitante.</param>
/// <param name="FirstName">El nombre del solicitante.</param>
/// <param name="LastName">El apellido del solicitante.</param>
/// <param name="Password">La contraseña del solicitante.</param>
/// <returns>Un resultado del comando que indica el éxito o fracaso de la operación.</returns>
public sealed record CreateApplicantCommand(string Email, string FirstName, string LastName, string Password)
    : ICommand<Result>;