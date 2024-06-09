using AvBeacon.Application._Core.Abstractions.Data;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Domain._Core.Abstractions.Primitives.Result;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Repositories;

namespace AvBeacon.Application.JobApplications.Commands.CreateJobApplication;

/// <summary>Handler para el comando <see cref="CreateJobApplicationCommand" />.</summary>
public sealed class CreateJobApplicationCommandHandler(
    IJobApplicationRepository jobApplicationRepository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateJobApplicationCommand, Result<Guid>>
{
    /// <summary>Maneja la creación de una nueva aplicación de empleo.</summary>
    /// <param name="request">El comando de creación de aplicación de empleo.</param>
    /// <param name="cancellationToken">El token de cancelación.</param>
    /// <returns>Un resultado indicando el éxito o fracaso de la operación junto con el ID de la aplicación de empleo creada.</returns>
    public async Task<Result<Guid>> Handle(CreateJobApplicationCommand request, CancellationToken cancellationToken)
    {
        var jobApplication = new JobApplication(request.ApplicantId, request.JobOfferId);

        await jobApplicationRepository.AddAsync(jobApplication, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(jobApplication.Id);
    }
}