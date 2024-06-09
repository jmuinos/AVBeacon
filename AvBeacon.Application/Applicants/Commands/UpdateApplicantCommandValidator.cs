using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.Applicants.Commands;

/// <summary>Validador para el comando <see cref="UpdateApplicantCommand" />.</summary>
public sealed class UpdateApplicantCommandValidator : AbstractValidator<UpdateApplicantCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="UpdateApplicantCommandValidator" />.</summary>
    public UpdateApplicantCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty()
           .WithError(ValidationErrors.UpdateUser.UserIdIsRequired);

        RuleFor(x => x.FirstName)
           .NotEmpty()
           .When(x => !string.IsNullOrEmpty(x.FirstName))
           .WithError(ValidationErrors.UpdateUser.FirstNameIsRequired)
           .MaximumLength(75)
           .WithError(ValidationErrors.UpdateUser.FirstNameIsTooLong);

        RuleFor(x => x.LastName)
           .NotEmpty()
           .When(x => !string.IsNullOrEmpty(x.LastName))
           .WithError(ValidationErrors.UpdateUser.LastNameIsRequired)
           .MaximumLength(150)
           .WithError(ValidationErrors.UpdateUser.LastNameIsTooLong);
    }
}