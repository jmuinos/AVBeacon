using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Applicants.JobApplications;
using AvBeacon.Domain.Users.Recruiters.JobOffers;

namespace AvBeacon.Application.Commands.Users.Applicants.CreateJobApplication;

/// <summary>
///     Handler para el comando <see cref="CreateJobApplicationCommand" />
/// </summary>
internal sealed record CreateJobApplicationCommandHandler : ICommandHandler<CreateJobApplicationCommand, Result>
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IJobApplicationRepository _jobApplicationRepository;
    private readonly IJobOfferRepository _jobOfferRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserIdentifierProvider _userIdentifierProvider;

    public CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository,
        IJobOfferRepository jobOfferRepository, IApplicantRepository applicantRepository, IUnitOfWork unitOfWork,
        IUserIdentifierProvider userIdentifierProvider)
    {
        _userIdentifierProvider   = userIdentifierProvider;
        _jobApplicationRepository = jobApplicationRepository;
        _jobOfferRepository       = jobOfferRepository;
        _applicantRepository      = applicantRepository;
        _unitOfWork               = unitOfWork;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        if (request.ApplicantId != _userIdentifierProvider.UserId)
            return Result.Failure(DomainErrors.Users.InvalidPermissions);

        var maybeApplicant = _applicantRepository.GetByIdAsync(request.ApplicantId).Result;
        var jobOffer = _jobOfferRepository.GetByIdAsync(request.JobOfferId).Result;

        var alreadyExists = _jobApplicationRepository
                            .GetByApplicantIdAsync(request.ApplicantId, cancellationToken)
                            .Result.Any(ja => ja.ApplicantId == request.ApplicantId);

        if (jobOffer.HasNoValue)
            return Result.Failure(DomainErrors.JobOffers.NotFound);

        if (alreadyExists)
            return Result.Failure(DomainErrors.JobApplications.AlreadyExists);

        var applicant = maybeApplicant.Value;
        var jobApplication = applicant.CreateJobApplication(jobOffer);

        _jobApplicationRepository.Insert(jobApplication);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}