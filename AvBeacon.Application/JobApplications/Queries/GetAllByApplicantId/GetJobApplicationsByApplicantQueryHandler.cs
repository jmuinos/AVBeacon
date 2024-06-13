using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobApplications.Queries.GetAllByApplicantId;

/// <summary> Representa el manejador de la consulta <see cref="GetJobApplicationsByApplicantQuery" />. </summary>
internal sealed class
    GetJobApplicationsByApplicantQueryHandler : IQueryHandler<GetJobApplicationsByApplicantQuery,
    List<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="GetJobApplicationsByApplicantQueryHandler" />. </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetJobApplicationsByApplicantQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

    /// <inheritdoc />
    public async Task<List<JobApplicationResponse>> Handle(GetJobApplicationsByApplicantQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplications = await _dbContext.Set<JobApplication>()
                                              .Where(ja => ja.ApplicantId ==
                                                           request.ApplicantId)
                                              .Select(ja => new JobApplicationResponse
                                               {
                                                   Id = ja.Id,
                                                   JobOfferId = ja.JobOfferId,
                                                   ApplicantId = ja.ApplicantId,
                                                   State = ja.State.Name,
                                                   JobOfferTitle = ja.JobOffer.Title.Value
                                               })
                                              .ToListAsync(cancellationToken);

        return jobApplications;
    }
}