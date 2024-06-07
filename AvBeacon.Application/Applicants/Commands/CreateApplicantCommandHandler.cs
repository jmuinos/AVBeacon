using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AvBeacon.Application.Applicants.Commands;

public class CreateApplicantCommandHandler(
    IApplicantRepository applicantRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher<User> passwordHasher)
    : IRequestHandler<CreateApplicantCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
    {
        var existingApplicant = await applicantRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingApplicant != null) return Result.Failure<Guid>(DomainErrors.User.DuplicateEmail);

        var applicant = new Applicant(request.Email, request.FirstName,
                                      request.LastName, request.Password);
        applicant.SetPassword(request.Password, passwordHasher);

        await applicantRepository.AddAsync(applicant, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(applicant.Id);
    }
}