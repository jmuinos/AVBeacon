using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.UpdateJobOffer;

public class UpdateJobOfferCommand(Guid id, string title, string description) : IRequest<Result>
{
    public Guid Id { get; init; } = id;
    public string? Title { get; set; } = title;
    public string? Description { get; set; } = description;
}