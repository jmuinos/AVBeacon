using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.Experiences.Commands.Create;

/// <summary> Representa el validador para el comando <see cref="CreateExperienceCommand" />. </summary>
internal sealed class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    /// <summary> Inicializa una nueva instancia de la clase <see cref="CreateExperienceCommandValidator" />. </summary>
    public CreateExperienceCommandValidator()
    {
        RuleFor(x => x.ApplicantId)
            .NotEmpty()
            .WithError(ValidationErrors.CreateExperience.ApplicantIdIsRequired);

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithError(ValidationErrors.CreateExperience.TitleIsRequired);

        RuleFor(x => x.Start)
            .LessThan(x => x.End)
            .When(x => x.End.HasValue)
            .WithError(ValidationErrors.CreateExperience.StartMustBeEarlierThanEnd);
    }
}