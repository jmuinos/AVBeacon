using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Recruiters.JobOffers;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Queries.JobApplications.GetById;

/// <summary>
///     Representa el manejador de consultas para <see cref="GetJobApplicationByIdQuery" />.
/// </summary>
internal sealed class
    GetJobApplicationByIdQueryHandler
    : IQueryHandler<GetJobApplicationByIdQuery,
        Maybe<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetJobApplicationByIdQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de la base de datos. </param>
    public GetJobApplicationByIdQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<Maybe<JobApplicationResponse>> Handle(GetJobApplicationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplicationResponse = await (from ja in _dbContext.Set<JobApplication>()
                                            join jo in _dbContext.Set<JobOffer>() on ja.JobOfferId equals jo.Id
                                            where ja.Id == request.JobApplicationId
                                            select new JobApplicationResponse
                                            {
                                                Id            = ja.Id,
                                                ApplicantId   = ja.ApplicantId,
                                                JobOfferId    = ja.JobOfferId,
                                                JobOfferTitle = jo.Title.Value,
                                                State         = ja.State.ToString()!
                                            }).SingleOrDefaultAsync(cancellationToken);

        return jobApplicationResponse is not null
                   ? Maybe<JobApplicationResponse>.From(jobApplicationResponse)
                   : Maybe<JobApplicationResponse>.None!;
    }
}