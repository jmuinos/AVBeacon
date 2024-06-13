using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.Update;

internal sealed class UpdateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateJobOfferCommand, Result>
{
    public async Task<Result> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
    {
        var titleResult = Title.Create(request.Title);
        var descriptionResult = Description.Create(request.Description);

        var firstFailureOrSuccess =
            Result.FirstFailureOrSuccess(titleResult, descriptionResult);

        if (firstFailureOrSuccess.IsFailure)
            return Result.Failure<TokenResponse>(firstFailureOrSuccess.Error);

        var jobOffer = await jobOfferRepository.GetByIdAsync(request.Id);
        if (jobOffer.HasNoValue)
            return Result.Failure(DomainErrors.JobOffer.NotFound);

        jobOffer.Value.Title = titleResult.Value;
        jobOffer.Value.Description = descriptionResult.Value;

        jobOfferRepository.Update(jobOffer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}