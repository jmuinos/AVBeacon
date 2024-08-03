using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Educations;

namespace AvBeacon.Application.Queries.Users.Applicants.GetEducations;

/// <summary>
///     Representa la consulta para obtener todas las educaciones de un solicitante.
/// </summary>
public sealed record GetApplicantEducationsQuery(Guid ApplicantId) : IQuery<List<EducationResponse>>;