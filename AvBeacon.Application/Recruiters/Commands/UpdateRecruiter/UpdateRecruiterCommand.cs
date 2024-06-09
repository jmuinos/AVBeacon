using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Recruiters.Commands.UpdateRecruiter;

/// <summary>
///     Representa el comando para actualizar un reclutador.
/// </summary>
/// <param name="Id">El identificador del reclutador.</param>
/// <param name="FirstName">El nombre del reclutador.</param>
/// <param name="LastName">El apellido del reclutador.</param>
public sealed record UpdateRecruiterCommand(
    Guid Id,
    string? FirstName,
    string? LastName) : ICommand<Result>;