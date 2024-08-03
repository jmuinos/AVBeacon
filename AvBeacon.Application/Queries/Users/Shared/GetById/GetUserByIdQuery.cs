using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Users;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.Queries.Users.Shared.GetById;

/// <summary>
///     Representa la consulta para obtener un usuario por ID.
/// </summary>
public sealed record GetUserByIdQuery(Guid UserId) : IQuery<Maybe<UserResponse>>;