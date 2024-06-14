using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.Users.Commands.Create;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string UserType
)
    : ICommand<Result<TokenResponse>>;