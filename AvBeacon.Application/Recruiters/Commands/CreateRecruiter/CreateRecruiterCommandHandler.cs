using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace AvBeacon.Application.Recruiters.Commands.CreateRecruiter;

/// <summary> Handler para el comando <see cref="CreateRecruiterCommand" />.</summary>
public sealed class CreateRecruiterCommandHandler(
    IRecruiterRepository recruiterRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher<User> passwordHasher) : ICommandHandler<CreateRecruiterCommand, Result<Guid>>
{
    /// <summary>Maneja la creación de un nuevo reclutador.</summary>
    /// <param name="request">El comando de creación de reclutador.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación.</returns>
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