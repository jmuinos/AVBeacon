using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.JobOffers.Queries.GetById;

/// <summary> Representa la consulta para obtener una oferta de trabajo por su identificador. </summary>
public sealed record GetJobOfferByIdQuery(Guid JobOfferId) : IQuery<Maybe<JobOfferResponse>>;