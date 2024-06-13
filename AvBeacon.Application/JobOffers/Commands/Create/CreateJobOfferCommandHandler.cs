using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.Create;

/// <summary> Handler para el comando <see cref="CreateJobOfferCommand" />. </summary>
internal sealed class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, Result>
{
    private readonly IJobOfferRepository _jobOfferRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
    {
        _jobOfferRepository = jobOfferRepository;
        _unitOfWork = unitOfWork;
    }

    /// <summary> Maneja la creación de una nueva oferta de empleo. </summary>
    /// <param name="request"> El comando de creación de oferta de empleo. </param>
    /// <param name="cancellationToken"> El token de cancelación. </param>
    /// <returns> Un resultado indicando el éxito o fracaso de la operación. </returns>
    public async Task<Result> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
    {
        var titleResult = Title.Create(request.Title);
        var descriptionResult = Description.Create(request.Description);

        var firstFailureOrSuccess =
            Result.FirstFailureOrSuccess(titleResult, descriptionResult);

        if (firstFailureOrSuccess.IsFailure)
            return Result.Failure<TokenResponse>(firstFailureOrSuccess.Error);

        var jobOffer = new JobOffer(request.RecruiterId, titleResult.Value, descriptionResult.Value);

        _jobOfferRepository.Insert(jobOffer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(jobOffer.Id);
    }
}