using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain._Shared;
using AvBeacon.Domain.Users.Applicants;
using AvBeacon.Domain.Users.Applicants.Educations;

namespace AvBeacon.Application.Commands.Users.Applicants.CreateEducation;

/// <summary>
///     Representa el handler de comandos para <see cref="CreateEducationCommand" />.
/// </summary>
internal sealed class CreateEducationCommandHandler : ICommandHandler<CreateEducationCommand, Result>
{
    private readonly IDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserIdentifierProvider _userIdentifierProvider;

    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="CreateEducationCommandHandler" />.
    /// </summary>
    /// <param name="unitOfWork"> La unidad de trabajo. </param>
    /// <param name="dbContext"> El contexto de base de datos. </param>
    /// <param name="userIdentifierProvider"> </param>
    public CreateEducationCommandHandler(IUnitOfWork unitOfWork, IDbContext dbContext,
        IUserIdentifierProvider userIdentifierProvider)
    {
        _unitOfWork             = unitOfWork;
        _dbContext              = dbContext;
        _userIdentifierProvider = userIdentifierProvider;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
    {
        if (request.ApplicantId != _userIdentifierProvider.UserId)
            return Result.Failure(DomainErrors.Users.InvalidPermissions);

        var maybeApplicant = await _dbContext.GetByIdAsync<Applicant>(request.ApplicantId);
        if (maybeApplicant.HasNoValue)
            return Result.Failure(DomainErrors.Applicants.NotFound);

        var maybeEducationType = EducationType.FromValue(request.EducationType);
        if (maybeEducationType.HasNoValue)
            return Result.Failure(DomainErrors.Educations.InvalidEducationType);

        var applicant = maybeApplicant.Value;
        var education = applicant.CreateEducation(Title.Create(request.Title).Value,
                                                  Description.Create(request.Description).Value,
                                                  maybeEducationType.Value);

        _dbContext.Set<Education>().Add(education);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}