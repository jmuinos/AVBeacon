using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;
using MediatR;

namespace AvBeacon.Application.Experiences.Commands.CreateExperience;

/// <summary>Handler para el comando <see cref="CreateExperienceCommand" />.</summary>
/// <param name="experienceRepository">El repositorio de experiencias.</param>
/// <param name="unitOfWork">La unidad de trabajo.</param>
public class CreateExperienceCommandHandler(IExperienceRepository experienceRepository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateExperienceCommand, Result<Guid>>
{
    /// <summary>Maneja la creación de una nueva experiencia.</summary>
    /// <param name="request">El comando de creación de experiencia.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado que indica el éxito o fracaso de la operación junto con el ID de la experiencia creada.</returns>
    public async Task<Result<Guid>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        var experience = new Experience(request.Title, request.Description, request.RecruiterName,
                                        request.Start, request.End, request.ApplicantId);

        await experienceRepository.AddAsync(experience, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(experience.Id);
    }
}