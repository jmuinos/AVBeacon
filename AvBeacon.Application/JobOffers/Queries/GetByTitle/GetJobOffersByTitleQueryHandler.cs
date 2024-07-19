using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobOffers;
using AvBeacon.Domain.Recruiters;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobOffers.Queries.GetByTitle;

/// <summary> Representa el manejador de la consulta <see cref="GetJobOffersByTitleQuery" />. </summary>
internal sealed class
    GetJobOffersByTitleQueryHandler : IQueryHandler<GetJobOffersByTitleQuery, List<JobOfferResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="GetJobOffersByTitleQueryHandler" />. </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetJobOffersByTitleQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

    /// <inheritdoc />
    public async Task<List<JobOfferResponse>> Handle(GetJobOffersByTitleQuery request,
        CancellationToken cancellationToken)
    {
        var jobOffers = await _dbContext.Set<JobOffer>()
            .Where(jo => EF.Functions.Like(jo.Title.Value,
                $"%{request.Title}%"))
            .Select(jo => new JobOfferResponse
            {
                Id = jo.Id,
                Title = jo.Title.Value,
                Description = jo.Description.Value,
                RecruiterId = jo.RecruiterId
            })
            .ToListAsync(cancellationToken);

        return jobOffers;
    }
}