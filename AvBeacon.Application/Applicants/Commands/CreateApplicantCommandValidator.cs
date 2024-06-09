using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.Applicants.Commands;

/// <summary>Validador para el comando <see cref="CreateApplicantCommand" />.</summary>
public sealed class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="CreateApplicantCommandValidator" />.</summary>
    public CreateApplicantCommandValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty()
           .WithError(ValidationErrors.CreateUser.EmailIsRequired)
           .EmailAddress()
           .WithError(ValidationErrors.CreateUser.InvalidEmailFormat);

        RuleFor(x => x.FirstName)
           .NotEmpty()
           .WithError(ValidationErrors.CreateUser.FirstNameIsRequired)
           .MaximumLength(75)
           .WithError(ValidationErrors.CreateUser.FirstNameIsTooLong);

        RuleFor(x => x.LastName)
           .NotEmpty()
           .WithError(ValidationErrors.CreateUser.LastNameIsRequired)
           .MaximumLength(150)
           .WithError(ValidationErrors.CreateUser.LastNameIsTooLong);

        RuleFor(x => x.Password)
           .NotEmpty()
           .WithError(ValidationErrors.CreateUser.PasswordIsRequired)
           .MinimumLength(6)
           .WithError(ValidationErrors.CreateUser.PasswordTooShort);
    }
}