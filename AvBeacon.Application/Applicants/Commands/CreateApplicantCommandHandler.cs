using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace AvBeacon.Application.Applicants.Commands;

/// <summary>Handler para el comando <see cref="CreateApplicantCommand" /></summary>
public class CreateApplicantCommandHandler(
    IApplicantRepository applicantRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher<User> passwordHasher) : ICommandHandler<CreateApplicantCommand, Result>
{
    /// <summary>Maneja la creación de un nuevo solicitante.</summary>
    /// <param name="request">El comando de creación de solicitante.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación.</returns>
    public async Task<Result> Handle(CreateApplicantCommand request, CancellationToken cancellationToken)
    {
        var existingApplicant = await applicantRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existingApplicant != null) return Result.Failure<Guid>(DomainErrors.User.DuplicateEmail);

        var applicant = new Applicant(request.Email, request.FirstName, request.LastName, request.Password);
        applicant.SetPassword(request.Password, passwordHasher);

        await applicantRepository.AddAsync(applicant, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(applicant.Id);
    }
}