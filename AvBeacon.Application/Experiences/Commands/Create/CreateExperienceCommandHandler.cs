using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Common;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives.Result;

namespace AvBeacon.Application.Experiences.Commands.Create;

/// <summary>
///     Representa el manejador de comandos para <see cref="CreateExperienceCommand" />.
/// </summary>
internal sealed class CreateExperienceCommandHandler : ICommandHandler<CreateExperienceCommand, Result>
{
    private readonly IDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="CreateExperienceCommandHandler" />.
    /// </summary>
    /// <param name="unitOfWork"> La unidad de trabajo. </param>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public CreateExperienceCommandHandler(IUnitOfWork unitOfWork, IDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext  = dbContext;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        var maybeApplicant = await _dbContext.GetByIdAsync<Applicant>(request.ApplicantId);

        if (maybeApplicant.HasNoValue) return Result.Failure(DomainErrors.Applicants.NotFound);

        var titleResult = Title.Create(request.Title);
        var descriptionResult = Description.Create(request.Description);

        var firstFailureOrSuccess = Result.FirstFailureOrSuccess(titleResult, descriptionResult);

        if (firstFailureOrSuccess.IsFailure) return Result.Failure(firstFailureOrSuccess.Error);

        var experience = Experience.Create(
            request.ApplicantId,
            titleResult.Value,
            descriptionResult.Value,
            request.Start,
            request.End);

        _dbContext.Insert(experience);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}