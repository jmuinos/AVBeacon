using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Maybe;
using AvBeacon.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.JobApplications.Queries.GetById;

/// <summary> Representa el manejador de consultas para <see cref="GetJobApplicationByIdQuery" />. </summary>
internal sealed class
    GetJobApplicationByIdQueryHandler : IQueryHandler<GetJobApplicationByIdQuery,
    Maybe<JobApplicationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="GetJobApplicationByIdQueryHandler" />. </summary>
    /// <param name="dbContext"> El contexto de la base de datos. </param>
    public GetJobApplicationByIdQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

    /// <inheritdoc />
    public async Task<Maybe<JobApplicationResponse>> Handle(
        GetJobApplicationByIdQuery request,
        CancellationToken cancellationToken)
    {
        var jobApplicationResponse = await _dbContext.Set<JobApplication>()
                                                     .Where(ja => ja.Id == request.JobApplicationId)
                                                     .Select(ja => new JobApplicationResponse
                                                      {
                                                          Id = ja.Id,
                                                          ApplicantId = ja.ApplicantId,
                                                          JobOfferId = ja.JobOfferId,
                                                          JobOfferTitle = ja.JobOffer.Title.Value,
                                                          State = ja.State.ToString()!
                                                      })
                                                     .SingleOrDefaultAsync(cancellationToken);

        return jobApplicationResponse is not null
                   ? Maybe<JobApplicationResponse>.From(jobApplicationResponse)
                   : Maybe<JobApplicationResponse>.None!;
    }
}