using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Commands.Users.Shared.UpdateUser;

/// <summary>
///     Represents the update user command.
/// </summary>
public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand<Result>;