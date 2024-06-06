// AvBeacon.Application/Applicants/Commands/CreateApplicantCommandHandler.cs

using AvBeacon.Application.Core.Data;
using AvBeacon.Domain.Applicants;
using MediatR;

namespace AvBeacon.Application.Applicant.Commands
{
    public class CreateApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateApplicantCommand, Guid>
    {
        public async Task<Guid> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = new Domain.Applicants.Applicant(Guid.NewGuid(), request.Email, request.FirstName, request.LastName);
            await applicantRepository.AddAsync(applicant, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return applicant.Id;
        }
    }
}