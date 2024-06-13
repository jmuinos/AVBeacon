using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;

namespace AvBeacon.Application.Skills.Queries.GetByApplicantId;

/// <summary> Representa la consulta para obtener todas las habilidades de un solicitante. </summary>
public sealed record GetSkillsByApplicantIdQuery(Guid ApplicantId) : IQuery<List<SkillResponse>>;