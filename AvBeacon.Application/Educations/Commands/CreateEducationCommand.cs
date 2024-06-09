using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.Educations.Commands;

/// <summary>Representa el comando para crear una educación.</summary>
/// <param name="EducationType">El tipo de educación.</param>
/// <param name="Description">La descripción de la educación.</param>
/// <param name="Start">La fecha de inicio de la educación.</param>
/// <param name="End">La fecha de finalización de la educación.</param>
/// <param name="ApplicantId">El identificador del solicitante.</param>
public sealed record CreateEducationCommand(
    string EducationType,
    string Description,
    DateTime Start,
    DateTime End,
    Guid ApplicantId)
    : ICommand<Result<Guid>>;