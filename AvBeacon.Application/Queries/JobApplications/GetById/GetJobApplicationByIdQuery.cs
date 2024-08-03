using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobApplications;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.Queries.JobApplications.GetById;

/// <summary>
///     Representa la consulta para obtener una solicitud de trabajo por su identificador.
/// </summary>
public sealed record GetJobApplicationByIdQuery(Guid JobApplicationId) : IQuery<Maybe<JobApplicationResponse>>;