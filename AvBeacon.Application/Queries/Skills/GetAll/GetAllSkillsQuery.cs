using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Skills;

namespace AvBeacon.Application.Queries.Skills.GetAll;

/// <summary>
///     Representa la consulta para obtener todas las habilidades.
/// </summary>
public sealed record GetAllSkillsQuery : IQuery<List<SkillResponse>>;