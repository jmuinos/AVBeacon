using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.Recruiters.Commands.UpdateRecruiter;

/// <summary>Validador para el comando <see cref="UpdateRecruiterCommand" />.</summary>
public sealed class UpdateRecruiterCommandValidator : AbstractValidator<UpdateRecruiterCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="UpdateRecruiterCommandValidator" />.</summary>
    public UpdateRecruiterCommandValidator()
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