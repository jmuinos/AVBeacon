using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Skills;
using AvBeacon.Domain.Applicants;
using Microsoft.EntityFrameworkCore;

namespace AvBeacon.Application.Skills.Queries.GetAll;

/// <summary> Representa el manejador de la consulta <see cref="GetAllSkillsQuery" />. </summary>
internal sealed class GetAllSkillsQueryHandler : IQueryHandler<GetAllSkillsQuery, List<SkillResponse>>
{
    private readonly IDbContext _dbContext;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="GetAllSkillsQueryHandler" />. </summary>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public GetAllSkillsQueryHandler(IDbContext dbContext) { _dbContext = dbContext; }

    /// <inheritdoc />
    public async Task<List<SkillResponse>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        var skills = await _dbContext.Set<Skill>()
            .Select(s => new SkillResponse { Id = s.Id, Title = s.Title })
            .ToListAsync(cancellationToken);

        return skills;
    }
}