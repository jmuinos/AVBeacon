using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Users;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Users.Shared;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Queries.Users.Shared.GetById;

/// <summary>
///     Representa el hadler de la consulta <see cref="GetUserByIdQuery" />.
/// </summary>
internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, Maybe<UserResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetUserByIdQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetUserByIdQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<Maybe<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId == Guid.Empty) return Maybe<UserResponse>.None!;
        var response = await _dbContext.Set<User>()
                                       .Where(x => x.Id == request.UserId)
                                       .Select(user => new UserResponse
                                       {
                                           Id        = user.Id,
                                           FirstName = user.FirstName.Value,
                                           LastName  = user.LastName.Value,
                                           FullName  = user.FullName,
                                           Email     = user.Email.Value
                                       })
                                       .SingleOrDefaultAsync(cancellationToken);


        if (response is null) return Maybe<UserResponse>.None!;

        return response;
    }
}