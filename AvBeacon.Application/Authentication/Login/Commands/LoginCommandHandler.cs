using AvBeacon.Application.Abstractions.Authentication;
using AvBeacon.Application.Abstractions.Messaging;
using AvBeacon.Contracts.Authentication;
using AvBeacon.Domain.Core.Errors;
using AvBeacon.Domain.Core.Primitives.Result;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.Users;

namespace AvBeacon.Application.Authentication.Login.Commands;

/// <summary> Represents the <see cref="LoginCommand" /> handler. </summary>
internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result<TokenResponse>>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IPasswordHashChecker _passwordHashChecker;
    private readonly IUserRepository _userRepository;

    /// <summary> Initializes a new instance of the <see cref="LoginCommandHandler" /> class. </summary>
    /// <param name="userRepository"> The user repository. </param>
    /// <param name="passwordHashChecker"> The password hash checker. </param>
    /// <param name="jwtProvider"> The JWT provider. </param>
    public LoginCommandHandler(IUserRepository userRepository, IPasswordHashChecker passwordHashChecker,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHashChecker = passwordHashChecker;
        _jwtProvider = jwtProvider;
    }

    /// <inheritdoc />
    public async Task<Result<TokenResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var emailResult = Email.Create(command.Email);
        if (emailResult.IsFailure)
            return Result.Failure<TokenResponse>(DomainErrors.Authentication.EmailNotFound);

        var maybeUser = await _userRepository.GetByEmailAsync(emailResult.Value);
        if (maybeUser.HasNoValue)
            return Result.Failure<TokenResponse>(DomainErrors.Authentication.UserNotFound);

        var user = maybeUser.Value;
        var passwordValid = user.VerifyPasswordHash(command.Password, _passwordHashChecker);

        if (!passwordValid)
            return Result.Failure<TokenResponse>(DomainErrors.Authentication.InvalidPassword);

        var token = _jwtProvider.Create(user);

        return Result.Success(new TokenResponse(token));
    }
}