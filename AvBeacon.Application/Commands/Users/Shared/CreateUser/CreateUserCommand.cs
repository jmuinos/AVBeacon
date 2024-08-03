using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Authentication;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Commands.Users.Shared.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string UserType
)
    : ICommand<Result<TokenResponse>>;