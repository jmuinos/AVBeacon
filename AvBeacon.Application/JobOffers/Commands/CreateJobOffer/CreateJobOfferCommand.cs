using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.CreateJobOffer;

public class CreateJobOfferCommand(Guid recruiterId, string title, string description) : IRequest<Result<Guid>>
{
    public required Guid RecruiterId { get; init; } = recruiterId;
    public required string Title { get; set; } = title;
    public required string Description { get; set; } = description;
}