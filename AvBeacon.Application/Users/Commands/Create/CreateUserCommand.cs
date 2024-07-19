using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Authentication;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.Users.Commands.Create;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string UserType
)
    : ICommand<Result<TokenResponse>>;