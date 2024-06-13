using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Primitives.Result;

namespace AvBeacon.Application.JobOffers.Commands.Create;

/// <summary> Representa el comando para crear una oferta de empleo. </summary>
/// <param name="RecruiterId"> El ID del reclutador que crea la oferta. </param>
/// <param name="Title"> El título de la oferta de empleo. </param>
/// <param name="Description"> La descripción de la oferta de empleo. </param>
/// <returns> Un resultado del comando que indica el éxito o fracaso de la operación. </returns>
public sealed record CreateJobOfferCommand(Guid RecruiterId, string Title, string Description)
    : ICommand<Result<Guid>>;