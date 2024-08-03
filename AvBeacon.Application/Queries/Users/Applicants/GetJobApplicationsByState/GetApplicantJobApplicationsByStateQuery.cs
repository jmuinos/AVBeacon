using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain.Users.Applicants.JobApplications;

namespace AvBeacon.Application.Queries.Users.Applicants.GetJobApplicationsByState;

/// <summary>
///     Representa la consulta para obtener todas las solicitudes de empleo de un solicitante por su estado.
/// </summary>
public sealed record GetApplicantJobApplicationsByStateQuery(Guid ApplicantId, JobApplicationState State)
    : IQuery<List<JobApplicationResponse>>;