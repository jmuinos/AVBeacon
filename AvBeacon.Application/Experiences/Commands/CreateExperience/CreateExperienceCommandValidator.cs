using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.Experiences.Commands.CreateExperience;

/// <summary>Validador para el comando <see cref="CreateExperienceCommand" />.</summary>
public sealed class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="CreateExperienceCommandValidator" />.</summary>
    public CreateExperienceCommandValidator()
    {
        RuleFor(x => x.ApplicantId)
           .NotEmpty()
           .WithError(ValidationErrors.CreateExperience.ApplicantIdIsRequired);

        RuleFor(x => x.Description)
           .MaximumLength(500)
           .WithError(ValidationErrors.CreateExperience.DescriptionTooLong);

        RuleFor(x => x.RecruiterName)
           .MaximumLength(150)
           .WithError(ValidationErrors.CreateExperience.RecruiterNameTooLong);

        RuleFor(x => x.Start)
           .LessThanOrEqualTo(x => x.End)
           .WithError(ValidationErrors.CreateExperience.StartMustBeEarlierThanEnd);

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithError(ValidationErrors.CreateExperience.TitleIsRequired)
           .MaximumLength(200)
           .WithError(ValidationErrors.CreateExperience.TitleTooLong);
    }
}