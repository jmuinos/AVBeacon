using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain.JobApplications;
using AvBeacon.Domain.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobApplications.Queries.GetAllByApplicantId;

/// <summary>
///     Representa el manejador de la consulta <see cref="GetJobApplicationsByApplicantQuery" />.
/// </summary>
internal sealed class
    GetJobApplicationsByApplicantQueryHandler
    : IQueryHandler<GetJobApplicationsByApplicantQuery,
        List<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetJobApplicationsByApplicantQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetJobApplicationsByApplicantQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<JobApplicationResponse>> Handle(GetJobApplicationsByApplicantQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplications = await (from ja in _dbContext.Set<JobApplication>()
                                     where ja.ApplicantId == request.ApplicantId
                                     join jo in _dbContext.Set<JobOffer>() on ja.JobOfferId equals jo.Id
                                     select new JobApplicationResponse
                                     {
                                         Id            = ja.Id,
                                         JobOfferId    = ja.JobOfferId,
                                         ApplicantId   = ja.ApplicantId,
                                         State         = ja.State.Name,
                                         JobOfferTitle = jo.Title.Value
                                     }).ToListAsync(cancellationToken);

        return jobApplications;
    }
}