using AvBeacon.Application.Core.Data;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Applicant.Commands;

public class CreateApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateApplicantCommand, Guid>
{
    public async Task<Guid> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
    {
        var applicant =
            new Domain.Entities.Applicant(Guid.NewGuid(), request.Email, request.FirstName, request.LastName);
        await applicantRepository.AddAsync(applicant, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return applicant.Id;
    }
}

public class CreateApplicantCommand : IRequest<Guid>
{
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}