using AvBeacon.Application.Core.Data;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Applicant.Commands;

public class UpdateApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateApplicantCommand>
{
    public async Task Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
    {
        var applicant = await applicantRepository.GetByIdAsync(request.Id, cancellationToken);
        if (applicant == null) throw new Exception("Applicant not found");
        applicant.UpdateDetails(request.Email, request.FirstName, request.LastName);
        applicantRepository.Update(applicant);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}

public class UpdateApplicantCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}