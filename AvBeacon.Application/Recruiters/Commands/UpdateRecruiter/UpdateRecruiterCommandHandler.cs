using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Errors;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Application.Recruiters.Commands.UpdateRecruiter;

/// <summary>
///     Handler para el comando <see cref="UpdateRecruiterCommand" />.
/// </summary>
public sealed class UpdateRecruiterCommandHandler(
    IRecruiterRepository recruiterRepository,
    IUnitOfWork unitOfWork) : ICommandHandler<UpdateRecruiterCommand, Result>
{
    /// <summary>
    ///     Maneja la actualización de un reclutador existente.
    /// </summary>
    /// <param name="request">El comando de actualización de reclutador.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación.</returns>
    public async Task<Result> Handle(UpdateRecruiterCommand request, CancellationToken cancellationToken)
    {
        var recruiter = await recruiterRepository.GetByIdAsync(request.Id, cancellationToken);
        if (recruiter == null) return Result.Failure(DomainErrors.Recruiter.NotFound);

        if (!string.IsNullOrEmpty(request.FirstName) && !string.IsNullOrEmpty(request.LastName))
            recruiter.ChangeName(request.FirstName, request.LastName);

        recruiterRepository.Update(recruiter);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}