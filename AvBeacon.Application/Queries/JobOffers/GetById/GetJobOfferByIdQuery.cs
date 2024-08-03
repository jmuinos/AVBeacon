using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.JobOffers;
using AvBeacon.Domain._Core.Primitives.Maybe;

namespace AvBeacon.Application.Queries.JobOffers.GetById;

/// <summary>
///     Representa la consulta para obtener una oferta de trabajo por su identificador.
/// </summary>
public sealed record GetJobOfferByIdQuery(Guid JobOfferId) : IQuery<Maybe<JobOfferResponse>>;