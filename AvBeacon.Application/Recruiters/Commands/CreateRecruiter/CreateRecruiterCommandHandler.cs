using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AvBeacon.Application.Recruiters.Commands.CreateRecruiter;

public class CreateRecruiterCommandHandler(
    IRecruiterRepository recruiterRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher<User> passwordHasher)
    : IRequestHandler<CreateRecruiterCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateRecruiterCommand request, CancellationToken cancellationToken)
    {
        var existingRecruiter = await recruiterRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingRecruiter != null) return Result.Failure<Guid>(DomainErrors.User.DuplicateEmail);

        var recruiter = new Recruiter(request.Email, request.FirstName, request.LastName, request.Password);

        recruiter.SetPassword(request.Password, passwordHasher);

        await recruiterRepository.AddAsync(recruiter, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(recruiter.Id);
    }
}