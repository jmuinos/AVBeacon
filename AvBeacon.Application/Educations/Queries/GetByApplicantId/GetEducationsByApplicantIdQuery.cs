using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Educations;

namespace AvBeacon.Application.Educations.Queries.GetByApplicantId
{
    /// <summary> Representa la consulta para obtener todas las educaciones de un solicitante. </summary>
    public sealed record GetEducationsByApplicantIdQuery(Guid ApplicantId) : IQuery<List<EducationResponse>>;
}