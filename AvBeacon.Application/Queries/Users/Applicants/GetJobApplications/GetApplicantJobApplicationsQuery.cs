using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;

namespace AvBeacon.Application.Queries.Users.Applicants.GetJobApplications;

/// <summary>
///     Representa la consulta para obtener todas las solicitudes de trabajo de un solicitante.
/// </summary>
public sealed record GetApplicantJobApplicationsQuery(Guid ApplicantId) : IQuery<List<JobApplicationResponse>>;