using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Authentication;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.Authentication.Login.Commands;

/// <summary>
///     Represents the login command.
/// </summary>
public sealed record LoginCommand(string Email, string Password)
    : ICommand<Result<TokenResponse>>;