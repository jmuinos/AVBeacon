using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Queries.Users.Applicants.GetJobApplications;

/// <summary>
///     Representa el manejador de la consulta <see cref="GetApplicantJobApplicationsQuery" />.
/// </summary>
internal sealed class
    GetApplicantJobApplicationsQueryHandler
    : IQueryHandler<GetApplicantJobApplicationsQuery,
        List<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetApplicantJobApplicationsQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetApplicantJobApplicationsQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<JobApplicationResponse>> Handle(GetApplicantJobApplicationsQuery request,
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