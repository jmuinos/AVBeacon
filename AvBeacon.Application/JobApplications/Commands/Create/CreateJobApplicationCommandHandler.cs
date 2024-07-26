using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives.Result;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Application.JobApplications.Commands.Create
{
    /// <summary> Handler para el comando <see cref="CreateJobApplicationCommand" /> </summary>
    internal sealed record CreateJobApplicationCommandHandler : ICommandHandler<CreateJobApplicationCommand, Result>
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateJobApplicationCommandHandler(IJobApplicationRepository jobApplicationRepository,
            IJobOfferRepository jobOfferRepository, IUnitOfWork unitOfWork)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _jobOfferRepository = jobOfferRepository;
            _unitOfWork = unitOfWork;
        }

        /// <inheritdoc />
        public async Task<Result> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
        {
            var jobOffer = _jobOfferRepository.GetByIdAsync(request.JobOfferId).Result;
            var alreadyExists = _jobApplicationRepository
                .GetByApplicantIdAsync(request.ApplicantId, cancellationToken)
                .Result.Any(ja => ja.ApplicantId == request.ApplicantId);

            if (jobOffer.HasNoValue)
                return Result.Failure(DomainErrors.JobOffer.NotFound);

            if (alreadyExists)
                return Result.Failure(DomainErrors.JobApplication.AlreadyExists);

            var jobApplication = JobApplication.Create(request.ApplicantId, request.JobOfferId);

            _jobApplicationRepository.Insert(jobApplication);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //TODO: Devolver id o no?
            return Result.Success(jobApplication.Id);
        }
    }
}