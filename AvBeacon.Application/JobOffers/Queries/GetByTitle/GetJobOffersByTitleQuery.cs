using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;

namespace AvBeacon.Application.JobOffers.Queries.GetByTitle;

/// <summary> Representa la consulta para filtrar ofertas de trabajo por su título. </summary>
public sealed record GetJobOffersByTitleQuery(string Title) : IQuery<List<JobOfferResponse>>;