using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Queries.Users.Applicants.GetJobApplicationsByState;

/// <summary>
///     Representa el handler de la consulta <see cref="GetApplicantJobApplicationsByStateQuery" />.
/// </summary>
internal sealed class
    GetApplicantJobApplicationsByStateQueryHandler
    : IQueryHandler<GetApplicantJobApplicationsByStateQuery,
        List<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetApplicantJobApplicationsByStateQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetApplicantJobApplicationsByStateQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<JobApplicationResponse>> Handle(GetApplicantJobApplicationsByStateQuery request,
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