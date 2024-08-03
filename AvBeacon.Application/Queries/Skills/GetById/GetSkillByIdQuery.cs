using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Skills;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.Queries.Skills.GetById;

/// <summary>
///     Representa la consulta para obtener una habilidad por su identificador.
/// </summary>
public sealed record GetSkillByIdQuery(Guid SkillId) : IQuery<Maybe<SkillResponse>>;