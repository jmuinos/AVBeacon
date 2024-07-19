using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Educations;
using AvBeacon.Domain.Applicants;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Educations.Queries.GetByApplicantId;

/// <summary> Representa el handler de la consulta <see cref="GetEducationsByApplicantIdQuery" />. </summary>
internal sealed class GetEducationsByApplicantIdQueryHandler
    : IQueryHandler<GetEducationsByApplicantIdQuery, List<EducationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="GetEducationsByApplicantIdQueryHandler" />. </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetEducationsByApplicantIdQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

    /// <inheritdoc />
    public async Task<List<EducationResponse>> Handle(GetEducationsByApplicantIdQuery request,
        CancellationToken cancellationToken)
    {
        var educations = await _dbContext.Set<Education>()
            .Where(e => e.ApplicantId == request.ApplicantId)
            .Select(e => new EducationResponse
            {
                Id = e.Id,
                Title = e.Title.Value,
                Description = e.Description.Value,
                EducationType = e.EducationType.Name,
                ApplicantId = e.ApplicantId
            })
            .ToListAsync(cancellationToken);
        return educations;
    }
}