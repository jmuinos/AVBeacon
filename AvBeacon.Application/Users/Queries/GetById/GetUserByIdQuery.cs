using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Users;
using AvBeacon.Domain.Core.Primitives.Maybe;

namespace AvBeacon.Application.Users.Queries.GetById
{
    /// <summary> Representa la consulta para obtener un usuario por ID. </summary>
    public sealed record GetUserByIdQuery(Guid UserId) : IQuery<Maybe<UserResponse>>;
}