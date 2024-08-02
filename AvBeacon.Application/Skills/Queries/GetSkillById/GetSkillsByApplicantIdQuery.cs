using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Skills;

namespace AvBeacon.Application.Skills.Queries.GetSkillById;

/// <summary>
///     Representa la consulta para obtener todas las habilidades de un solicitante.
/// </summary>
public sealed record GetSkillsByApplicantIdQuery(Guid ApplicantId)
    : IQuery<List<SkillResponse>>;