using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Application.Educations.Commands;

/// <summary>Handler para el comando <see cref="CreateEducationCommand" /></summary>
public sealed class CreateEducationCommandHandler(IEducationRepository educationRepository, IUnitOfWork unitOfWork)
    : ICommandHandler<CreateEducationCommand, Result<Guid>>
{
    /// <summary>Maneja la creación de una nueva educación.</summary>
    /// <param name="request">El comando de creación de educación.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación.</returns>
    public async Task<Result<Guid>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
    {
        var educationType = EducationType.FromString(request.EducationType);
        var education = new Education(educationType, request.Description,
                                      request.Start, request.End, request.ApplicantId);

        await educationRepository.AddAsync(education, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(education.Id);
    }
}