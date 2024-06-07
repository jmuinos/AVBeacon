using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.CreateJobOffer;

public class CreateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateJobOfferCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
    {
        var jobOffer = new JobOffer(request.RecruiterId, request.Title, request.Description);

        await jobOfferRepository.AddAsync(jobOffer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(jobOffer.Id);
    }
}