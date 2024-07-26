using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Skills;
using AvBeacon.Domain.Core.Primitives.Maybe;

namespace AvBeacon.Application.Skills.Queries.GetById
{
    /// <summary> Representa la consulta para obtener una habilidad por su identificador. </summary>
    public sealed record GetSkillByIdQuery(Guid SkillId) : IQuery<Maybe<SkillResponse>>;
}