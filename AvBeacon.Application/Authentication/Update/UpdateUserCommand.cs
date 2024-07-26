using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.Authentication.Update
{
    /// <summary> Represents the update user command. </summary>
    public sealed record UpdateUserCommand(Guid UserId, string FirstName, string LastName) : ICommand<Result>;
}