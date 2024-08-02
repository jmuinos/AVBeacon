using AvBeacon.Application.Core.Errors;
using AvBeacon.Application.Core.Extensions;
using FluentValidation;

namespace AvBeacon.Application.Authentication.Login.Commands;

/// <summary>
///     Represents the <see cref="LoginCommand" /> validator
/// </summary>
internal sealed class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="LoginCommandValidator" /> class
    /// </summary>
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithError(ValidationErrors.Login.EmailIsRequired);
        RuleFor(x => x.Password).NotEmpty().WithError(ValidationErrors.Login.PasswordIsRequired);
    }
}