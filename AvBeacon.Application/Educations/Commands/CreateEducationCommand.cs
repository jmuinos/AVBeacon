﻿using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.Educations.Commands;

/// <summary>
///     Representa el comando para crear una educación.
/// </summary>
public sealed record CreateEducationCommand(
    int EducationType,
    string Title,
    string Description,
    Guid ApplicantId
) : ICommand<Result>;