using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain.Applicants;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives.Result;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Application.Educations.Commands;

/// <summary> Representa el manejador de comandos para <see cref="CreateEducationCommand" />. </summary>
internal sealed class CreateEducationCommandHandler : ICommandHandler<CreateEducationCommand, Result>
{
    private readonly IDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    /// <summary> Inicializa una nueva instancia de la clase <see cref="CreateEducationCommandHandler" />. </summary>
    /// <param name="unitOfWork"> La unidad de trabajo. </param>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    public CreateEducationCommandHandler(IUnitOfWork unitOfWork, IDbContext dbContext)
    {
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
    {
        var maybeApplicant = await _dbContext.GetByIdAsync<Applicant>(request.ApplicantId);
        if (maybeApplicant.HasNoValue) return Result.Failure(DomainErrors.Applicant.NotFound);
        var maybeEducationType = EducationType.FromValue(request.EducationType);
        if (maybeEducationType.HasNoValue) return Result.Failure(DomainErrors.Education.InvalidEducationType);
        var education = Education.Create(
            maybeEducationType.Value,
            Title.Create(request.Title).Value,
            Description.Create(request.Description).Value,
            request.ApplicantId);

        _dbContext.Set<Education>().Add(education);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}