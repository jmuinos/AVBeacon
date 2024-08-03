using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants;

namespace AvBeacon.Application.Commands.Users.Applicants.CreateExperience;

/// <summary>
///     Representa el manejador de comandos para <see cref="CreateExperienceCommand" />.
/// </summary>
internal sealed class CreateExperienceCommandHandler : ICommandHandler<CreateExperienceCommand, Result>
{
    private readonly IDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserIdentifierProvider _userIdentifierProvider;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="CreateExperienceCommandHandler" />.
    /// </summary>
    /// <param name="unitOfWork"> La unidad de trabajo. </param>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    /// <param name="userIdentifierProvider"> </param>
    public CreateExperienceCommandHandler(IDbContext dbContext, IUserIdentifierProvider userIdentifierProvider,
        IUnitOfWork unitOfWork)
    {
        _userIdentifierProvider = userIdentifierProvider;
        _unitOfWork             = unitOfWork;
        _dbContext              = dbContext;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
    {
        if (request.ApplicantId != _userIdentifierProvider.UserId)
            return Result.Failure(DomainErrors.Users.InvalidPermissions);

        var maybeApplicant = await _dbContext.GetByIdAsync<Applicant>(request.ApplicantId);
        if (maybeApplicant.HasNoValue)
            return Result.Failure(DomainErrors.Applicants.NotFound);

        var titleResult = Title.Create(request.Title);
        var descriptionResult = Description.Create(request.Description);

        var firstFailureOrSuccess = Result.FirstFailureOrSuccess(titleResult, descriptionResult);
        if (firstFailureOrSuccess.IsFailure)
            return Result.Failure(firstFailureOrSuccess.Error);

        var applicant = maybeApplicant.Value;
        var experience = applicant.CreateExperience(titleResult.Value,
                                                    descriptionResult.Value,
                                                    request.Start,
                                                    request.End);

        _dbContext.Insert(experience);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}