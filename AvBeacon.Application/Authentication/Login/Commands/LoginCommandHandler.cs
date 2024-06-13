using AvBeacon.Application._Core.Abstractions.Authentication;
using AvBeacon.Application._Core.Abstractions.Messaging;
using AvBeacon.Contracts.Responses;
using AvBeacon.Domain._Core.Errors;
using AvBeacon.Domain._Core.Primitives.Result;
using AvBeacon.Domain.Repositories;
using AvBeacon.Domain.Services;
using AvBeacon.Domain.ValueObjects;

namespace AvBeacon.Application.Authentication.Login.Commands;

/// <summary> Represents the <see cref="LoginCommand" /> handler. </summary>
internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result<TokenResponse>>
{
    private readonly IJwtProvider _jwtProvider;
    private readonly IMyPasswordHashChecker _myPasswordHashChecker;
    private readonly IUserRepository _userRepository;

    /// <summary> Initializes a new instance of the <see cref="LoginCommandHandler" /> class. </summary>
    /// <param name="userRepository"> The user repository. </param>
    /// <param name="myPasswordHashChecker"> The password hash checker. </param>
    /// <param name="jwtProvider"> The JWT provider. </param>
    public LoginCommandHandler(IUserRepository userRepository, IMyPasswordHashChecker myPasswordHashChecker,
        IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _myPasswordHashChecker = myPasswordHashChecker;
        _jwtProvider = jwtProvider;
    }

    /// <inheritdoc />
    public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        //TODO: Comprobar que funcione buscar user de forma dinámica o si hay que inyectar repos específicos y configurar la búsqueda (SI HAY QUE HACERLO, CHUNGO)
        var emailResult = Email.Create(request.Email);

        if (emailResult.IsFailure)
            return Result.Failure<TokenResponse>(DomainErrors.Authentication.InvalidEmailOrPassword);

        var maybeUser = await _userRepository.GetByEmailAsync(emailResult.Value);

        if (maybeUser.HasNoValue)
            return Result.Failure<TokenResponse>(DomainErrors.Authentication.InvalidEmailOrPassword);

        var user = maybeUser.Value;

        var passwordValid = user.VerifyPasswordHash(request.Password, _myPasswordHashChecker);

        if (!passwordValid) return Result.Failure<TokenResponse>(DomainErrors.Authentication.InvalidEmailOrPassword);

        var token = _jwtProvider.Create(user);

        return Result.Success(new TokenResponse(token));
    }
}