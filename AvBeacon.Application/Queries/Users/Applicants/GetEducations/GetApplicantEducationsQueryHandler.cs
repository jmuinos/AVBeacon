using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Educations;
using AvBeacon.Domain.Users.Applicants.Educations;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Queries.Users.Applicants.GetEducations;

/// <summary>
///     Representa el handler de la consulta <see cref="GetApplicantEducationsQuery" />.
/// </summary>
internal sealed class GetApplicantEducationsQueryHandler
    : IQueryHandler<GetApplicantEducationsQuery, List<EducationResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="GetApplicantEducationsQueryHandler" />.
    /// </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetApplicantEducationsQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<EducationResponse>> Handle(GetApplicantEducationsQuery request,
        CancellationToken cancellationToken)
    {
        var educations = await _dbContext.Set<Education>()
                                         .Where(e => e.ApplicantId == request.ApplicantId)
                                         .Select(e => new EducationResponse
                                         {
                                             Id            = e.Id,
                                             Title         = e.Title.Value,
                                             Description   = e.Description.Value,
                                             EducationType = e.EducationType.Name,
                                             ApplicantId   = e.ApplicantId
                                         })
                                         .ToListAsync(cancellationToken);
        return educations;
    }
}