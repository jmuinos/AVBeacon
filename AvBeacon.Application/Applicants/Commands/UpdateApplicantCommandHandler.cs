using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Application.Applicants.Commands;

/// <summary> Handler para el comando <see cref="UpdateApplicantCommand" />. </summary>
public sealed class UpdateApplicantCommandHandler(IApplicantRepository applicantRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateApplicantCommand, Result>
{
    /// <summary>
    ///     Maneja la actualización de un solicitante existente.
    /// </summary>
    /// <param name="request">El comando de actualización de solicitante.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación.</returns>
    public async Task<Result> Handle(UpdateApplicantCommand request, CancellationToken cancellationToken)
    {
        var applicant = await applicantRepository.GetByIdAsync(request.Id, cancellationToken);
        if (applicant == null) return Result.Failure(DomainErrors.Applicant.NotFound);

        if (!string.IsNullOrEmpty(request.FirstName) && !string.IsNullOrEmpty(request.LastName))
            applicant.ChangeName(request.FirstName, request.LastName);

        applicantRepository.Update(applicant);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}