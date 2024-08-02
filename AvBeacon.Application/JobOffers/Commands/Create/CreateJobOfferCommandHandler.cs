using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Contracts.Authentication;
using AvBeacon.Domain.Common;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives.Result;
using AvBeacon.Domain.JobOffers;
using AvBeacon.Domain.Users.Recruiters;
using MediatR;

namespace AvBeacon.Application.JobOffers.Commands.Create;

/// <summary>
///     Handler para el comando <see cref="CreateJobOfferCommand" />.
/// </summary>
internal sealed class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, Result>
{
    private readonly IUserIdentifierProvider _userIdentifierProvider;
    private readonly IJobOfferRepository _jobOfferRepository;
    private readonly IRecruiterRepository _recruiterRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateJobOfferCommandHandler(IJobOfferRepository jobOfferRepository,
        IUserIdentifierProvider userIdentifierProvider, IUnitOfWork unitOfWork,
        IRecruiterRepository recruiterRepository)
    {
        _userIdentifierProvider = userIdentifierProvider;
        _jobOfferRepository     = jobOfferRepository;
        _recruiterRepository    = recruiterRepository;
        _unitOfWork             = unitOfWork;
    }

    /// <summary>
    ///     Maneja la creación de una nueva oferta de empleo.
    /// </summary>
    /// <param name="request"> El comando de creación de oferta de empleo. </param>
    /// <param name="cancellationToken"> El token de cancelación. </param>
    /// <returns> Un resultado indicando el éxito o fracaso de la operación. </returns>
    public async Task<Result> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
    {
        if (request.RecruiterId != _userIdentifierProvider.UserId)
            return Result.Failure(DomainErrors.Users.InvalidPermissions);

        var maybeRecruiter = _recruiterRepository.GetByIdAsync(request.RecruiterId).Result;
        if (maybeRecruiter.HasNoValue) 
           
            return Result.Failure(DomainErrors.Users.NotFound);
        
        var titleResult = Title.Create(request.Title);
        var descriptionResult = Description.Create(request.Description);

        var firstFailureOrSuccess =
            Result.FirstFailureOrSuccess(titleResult, descriptionResult);

        if (firstFailureOrSuccess.IsFailure)
            return Result.Failure<TokenResponse>(firstFailureOrSuccess.Error);

        var recruiter = maybeRecruiter.Value;
        var jobOffer = recruiter.CreateJobOffer(titleResult.Value, descriptionResult.Value);

        _jobOfferRepository.Insert(jobOffer);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(jobOffer.Id);
    }
}