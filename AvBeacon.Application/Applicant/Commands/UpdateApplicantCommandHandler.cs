using AvBeacon.Application.Core.Data;
using AvBeacon.Domain.Applicants;
using MediatR;

namespace AvBeacon.Application.Applicant.Commands
{
    public class UpdateApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateApplicantCommand>
    {
        public async Task Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
        {
            var applicant = await applicantRepository.GetByIdAsync(request.Id, cancellationToken);
            if (applicant == null)
            {
                throw new Exception("Applicant not found");
            }
            applicant.UpdateDetails(request.Email, request.FirstName, request.LastName);
            applicantRepository.Update(applicant);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}