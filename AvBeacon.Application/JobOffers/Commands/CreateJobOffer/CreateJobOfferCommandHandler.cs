using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.CreateJobOffer;

/// <summary>Handler para el comando <see cref="CreateJobOfferCommand" />.</summary>
public sealed class CreateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateJobOfferCommand, Result<Guid>>
{
    /// <summary>Maneja la creación de una nueva oferta de empleo.</summary>
    /// <param name="request">El comando de creación de oferta de empleo.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación.</returns>
    public async Task<Result<Guid>> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
    {
        var jobOffer = new JobOffer(request.RecruiterId, request.Title, request.Description);

        await jobOfferRepository.AddAsync(jobOffer, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(jobOffer.Id);
    }
}