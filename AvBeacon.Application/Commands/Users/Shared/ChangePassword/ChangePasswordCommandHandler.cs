using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Cryptography;
using AvBeacon.Application.Abstractions.Data;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Users.Shared;

namespace AvBeacon.Application.Commands.Users.Shared.ChangePassword;

/// <summary>
///     Represents the <see cref="ChangePasswordCommand" /> handler.
/// </summary>
internal sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand, Result>
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserIdentifierProvider _userIdentifierProvider;
    private readonly IUserRepository _userRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="ChangePasswordCommandHandler" /> class.
    /// </summary>
    /// <param name="userIdentifierProvider"> The user identifier provider. </param>
    /// <param name="userRepository"> The user repository. </param>
    /// <param name="unitOfWork"> The unit of work. </param>
    /// <param name="passwordHasher"> The password hasher. </param>
    public ChangePasswordCommandHandler(
        IUserIdentifierProvider userIdentifierProvider,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher)
    {
        _userIdentifierProvider = userIdentifierProvider;
        _userRepository         = userRepository;
        _unitOfWork             = unitOfWork;
        _passwordHasher         = passwordHasher;
    }

    /// <inheritdoc />
    public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        if (request.UserId != _userIdentifierProvider.UserId)
            return Result.Failure(DomainErrors.Users.InvalidPermissions);

        var passwordResult = Password.Create(request.Password);

        if (passwordResult.IsFailure) return Result.Failure(passwordResult.Error);

        var maybeApplicant = await _userRepository.GetByIdAsync(request.UserId);

        if (maybeApplicant.HasNoValue) return Result.Failure(DomainErrors.Applicants.NotFound);

        var user = maybeApplicant.Value;

        var passwordHash = _passwordHasher.HashPassword(passwordResult.Value);

        var result = user.ChangePassword(passwordHash);

        if (result.IsFailure) return Result.Failure(result.Error);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}