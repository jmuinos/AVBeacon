using AvBeacon.Application.Core.Errors;
using AvBeacon.Application.Core.Extensions;
using FluentValidation;

namespace AvBeacon.Application.Authentication.ChangePassword;

/// <summary> Represents the <see cref="ChangePasswordCommand" /> validator </summary>
internal sealed class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    /// <summary> Initializes a new instance of the <see cref="ChangePasswordCommandValidator" /> class. </summary>
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithError(ValidationErrors.ChangePassword.UserIdIsRequired);
        RuleFor(x => x.Password).NotEmpty().WithError(ValidationErrors.ChangePassword.PasswordIsRequired);
    }
}