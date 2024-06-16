using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.Educations.Commands;

/// <summary> Representa el validador para el comando <see cref="CreateEducationCommand" />. </summary>
internal sealed class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
{
    /// <summary> Inicializa una nueva instancia de la clase <see cref="CreateEducationCommandValidator" />. </summary>
    public CreateEducationCommandValidator()
    {
        RuleFor(x => x.EducationType).NotEmpty().WithError(ValidationErrors.CreateEducation.InvalidEducationType);
        RuleFor(x => x.Title).NotEmpty().WithError(ValidationErrors.CreateEducation.TitleIsRequired);
        RuleFor(x => x.Description).NotEmpty().WithError(ValidationErrors.CreateEducation.DescriptionIsRequired);
        RuleFor(x => x.ApplicantId).NotEmpty().WithError(ValidationErrors.CreateEducation.ApplicantIdIsRequired);
    }
}