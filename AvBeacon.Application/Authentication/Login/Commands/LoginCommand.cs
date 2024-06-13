using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Authentication.Login.Commands;

/// <summary> Represents the login command. </summary>
public sealed record LoginCommand(string Email, string Password) : ICommand<Result<TokenResponse>>;