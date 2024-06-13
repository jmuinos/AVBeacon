using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;

namespace AvBeacon.Application.Skills.Queries.GetAll;

/// <summary> Representa la consulta para obtener todas las habilidades. </summary>
public sealed record GetAllSkillsQuery : IQuery<List<SkillResponse>>;