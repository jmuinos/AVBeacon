using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobApplications.Queries.GetByApplicantIdAndState;

/// <summary>
///     Representa el handler de la consulta <see cref="GetJobApplicationsByApplicantIdAndStateQuery" />.
/// </summary>
internal sealed class
    GetJobApplicationsByApplicantIdAndStateQueryHandler
    : IQueryHandler<GetJobApplicationsByApplicantIdAndStateQuery,
        List<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetJobApplicationsByApplicantIdAndStateQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetJobApplicationsByApplicantIdAndStateQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<JobApplicationResponse>> Handle(GetJobApplicationsByApplicantIdAndStateQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplications = await (from ja in _dbContext.Set<JobApplication>()
                                     join jo in _dbContext.Set<JobOffer>() on ja.JobOfferId equals jo.Id
                                     where ja.ApplicantId == request.ApplicantId && ja.State == request.State
                                     select new JobApplicationResponse
                                     {
                                         Id            = ja.Id,
                                         JobOfferId    = ja.JobOfferId,
                                         JobOfferTitle = jo.Title.Value,
                                         State         = ja.State.Name,
                                         ApplicantId   = ja.ApplicantId
                                     }).ToListAsync(cancellationToken);

        return jobApplications;
    }
}