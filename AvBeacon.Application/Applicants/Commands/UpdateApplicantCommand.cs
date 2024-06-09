using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Applicants.Commands;

/// <summary> Representa el comando para actualizar un solicitante. </summary>
/// <param name="Id">El Id del solicitante a actualizar.</param>
/// <param name="FirstName">El nombre del solicitante.</param>
/// <param name="LastName">El apellido del solicitante.</param>
/// <returns>Un resultado del comando que indica el éxito o fracaso de la operación.</returns>
public sealed record UpdateApplicantCommand(
    Guid Id,
    string? FirstName,
    string? LastName) : ICommand<Result>;