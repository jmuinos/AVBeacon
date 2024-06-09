using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using AvBeacon.Domain.ValueObjects;
using FluentValidation;

namespace AvBeacon.Application.Educations.Commands;

/// <summary>Validador para el comando <see cref="CreateEducationCommand" />.</summary>
public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="CreateEducationCommandValidator" /></summary>
    public CreateEducationCommandValidator()
    {
        RuleFor(x => x.Description)
           .NotEmpty()
           .WithError(ValidationErrors.CreateEducation.DescriptionIsRequired)
           .MaximumLength(200)
           .WithError(ValidationErrors.CreateEducation.DescriptionTooLong);

        RuleFor(x => x.Start)
           .LessThanOrEqualTo(x => x.End)
           .WithError(ValidationErrors.CreateEducation.StartMustBeEarlierThanEnd);

        RuleFor(x => x.EducationType)
           .Must(BeAValidEducationType)
           .WithError(ValidationErrors.CreateEducation.InvalidEducationType);

        RuleFor(x => x.ApplicantId)
           .NotEmpty()
           .WithError(ValidationErrors.CreateEducation.ApplicantIdIsRequired);
    }

    /// <summary>Verifica si el tipo de educación es válido.</summary>
    /// <param name="educationType">El tipo de educación a validar.</param>
    /// <returns>True si el tipo de educación es válido; de lo contrario, false.</returns>
    private static bool BeAValidEducationType(string educationType)
    {
        return EducationType.TryFromString(educationType, out _);
    }
}