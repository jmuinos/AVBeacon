using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobApplications.Queries.GetByApplicantIdAndState;

/// <summary> Representa el manejador de la consulta <see cref="GetJobApplicationsByApplicantIdAndStateQuery" />. </summary>
internal sealed class
    GetJobApplicationsByApplicantIdAndStateQueryHandler : IQueryHandler<GetJobApplicationsByApplicantIdAndStateQuery,
    List<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetJobApplicationsByApplicantIdAndStateQueryHandler" />
    ///     .
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetJobApplicationsByApplicantIdAndStateQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

    /// <inheritdoc />
    public async Task<List<JobApplicationResponse>> Handle(GetJobApplicationsByApplicantIdAndStateQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplications = await _dbContext.Set<JobApplication>()
                                              .Where(ja => ja.ApplicantId == request.ApplicantId &&
                                                           ja.State == request.State)
                                              .Select(ja => new JobApplicationResponse
                                               {
                                                   Id = ja.Id,
                                                   JobOfferId = ja.JobOfferId,
                                                   JobOfferTitle = ja.JobOffer.Title.Value,
                                                   State = ja.State.Name,
                                                   ApplicantId = ja.ApplicantId
                                               })
                                              .ToListAsync(cancellationToken);

        return jobApplications;
    }
}