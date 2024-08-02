using AvBeacon.Application.Core.Errors;
using AvBeacon.Application.Core.Extensions;
using FluentValidation;

namespace AvBeacon.Application.JobApplications.Commands.Create;

/// <summary>
///     Validador para el comando <see cref="CreateJobApplicationCommand" />.
/// </summary>
internal sealed class CreateJobApplicationCommandValidator : AbstractValidator<CreateJobApplicationCommand>
{
    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="CreateJobApplicationCommandValidator" />.
    /// </summary>
    public CreateJobApplicationCommandValidator()
    {
        RuleFor(x => x.ApplicantId)
            .NotEmpty()
            .WithError(ValidationErrors.CreateJobApplication.ApplicantIdIsRequired);

        RuleFor(x => x.JobOfferId)
            .NotEmpty()
            .WithError(ValidationErrors.CreateJobApplication.JobOfferIdIsRequired);
    }
}