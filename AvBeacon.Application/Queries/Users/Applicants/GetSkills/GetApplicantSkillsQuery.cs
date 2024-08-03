using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Skills;

namespace AvBeacon.Application.Queries.Users.Applicants.GetSkills;

/// <summary>
///     Representa la consulta para obtener todas las habilidades de un solicitante.
/// </summary>
public sealed record GetApplicantSkillsQuery(Guid ApplicantId)
    : IQuery<List<SkillResponse>>;