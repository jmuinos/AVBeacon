using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.UpdateJobOffer;

public class UpdateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateJobOfferCommand, Result>
{
    public async Task<Result> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
    {
        var jobOffer = await jobOfferRepository.GetByIdAsync(request.Id, cancellationToken);
        if (jobOffer == null) return Result.Failure(DomainErrors.JobOffer.NotFound);

        if (request.Title != null && !request.Title.Equals(string.Empty)) jobOffer.Title = request.Title;

        if (request.Description != null && !request.Description.Equals(string.Empty))
            jobOffer.Description = request.Description;

        jobOfferRepository.Update(jobOffer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}