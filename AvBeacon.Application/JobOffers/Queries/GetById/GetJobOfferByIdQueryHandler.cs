using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobOffers;
using AvBeacon.Domain.Core.Primitives.Maybe;
using AvBeacon.Domain.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobOffers.Queries.GetById;

/// <summary>
///     Representa el manejador de consultas para <see cref="GetJobOfferByIdQuery" />.
/// </summary>
internal sealed class GetJobOfferByIdQueryHandler : IQueryHandler<GetJobOfferByIdQuery, Maybe<JobOfferResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetJobOfferByIdQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de la base de datos. </param>
    public GetJobOfferByIdQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<Maybe<JobOfferResponse>> Handle(GetJobOfferByIdQuery request, CancellationToken cancellationToken)
    {
        var jobOfferResponse = await _dbContext.Set<JobOffer>()
                                               .Where(jo => jo.Id == request.JobOfferId)
                                               .Select(jo => new JobOfferResponse
                                               {
                                                   Id          = jo.Id,
                                                   Title       = jo.Title.Value,
                                                   Description = jo.Description.Value,
                                                   RecruiterId = jo.RecruiterId
                                               })
                                               .SingleOrDefaultAsync(cancellationToken);

        return jobOfferResponse is not null
                   ? Maybe<JobOfferResponse>.From(jobOfferResponse)
                   : Maybe<JobOfferResponse>.None!;
    }
}