using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Application.Authentication.Update;

/// <summary> Represents the update user command. </summary>
public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand<Result>;