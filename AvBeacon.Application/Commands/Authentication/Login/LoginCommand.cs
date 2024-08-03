using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Authentication;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Commands.Authentication.Login;

/// <summary>
///     Represents the login command.
/// </summary>
public sealed record LoginCommand(string Email, string Password)
    : ICommand<Result<TokenResponse>>;