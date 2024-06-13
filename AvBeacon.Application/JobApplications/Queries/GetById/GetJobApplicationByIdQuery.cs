using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.JobApplications.Queries.GetById;

/// <summary> Representa la consulta para obtener una solicitud de trabajo por su identificador. </summary>
public sealed record GetJobApplicationByIdQuery(Guid JobApplicationId) : IQuery<Maybe<JobApplicationResponse>>;