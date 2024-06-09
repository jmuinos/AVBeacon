using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;

namespace AvBeacon.Application.JobOffers.Commands.UpdateJobOffer;

/// <summary> Representa el comando para actualizar una oferta de empleo. </summary>
/// <param name="Id">El ID de la oferta de empleo a actualizar.</param>
/// <param name="Title">El título de la oferta de empleo.</param>
/// <param name="Description">La descripción de la oferta de empleo.</param>
/// <returns>Un resultado del comando que indica el éxito o fracaso de la operación.</returns>
public sealed record UpdateJobOfferCommand(Guid Id, string Title, string Description)
    : ICommand<Result>;