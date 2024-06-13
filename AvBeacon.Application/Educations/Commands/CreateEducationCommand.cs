using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Educations.Commands;

/// <summary> Representa el comando para crear una educación. </summary>
public sealed record CreateEducationCommand(int EducationType, string Title, string Description, Guid ApplicantId)
    : ICommand<Result>;