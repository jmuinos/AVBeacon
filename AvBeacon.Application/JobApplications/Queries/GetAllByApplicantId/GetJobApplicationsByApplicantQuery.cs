using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;

namespace AvBeacon.Application.JobApplications.Queries.GetAllByApplicantId;

/// <summary> Representa la consulta para obtener todas las solicitudes de trabajo de un solicitante. </summary>
public sealed record GetJobApplicationsByApplicantQuery(Guid ApplicantId) : IQuery<List<JobApplicationResponse>>;