using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain.Applicants;

namespace AvBeacon.Application.JobApplications.Queries.GetByApplicantIdAndState;

/// <summary> Representa la consulta para obtener todas las solicitudes de empleo de un solicitante por su estado. </summary>
public sealed record GetJobApplicationsByApplicantIdAndStateQuery(Guid ApplicantId, JobApplicationState State)
    : IQuery<List<JobApplicationResponse>>;