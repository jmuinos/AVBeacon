using AvBeacon.Application._Core.Errors;
using AvBeacon.Application._Core.Extensions;
using FluentValidation;

namespace AvBeacon.Application.Commands.Users.Recruiters.ProcessJobApplication;

/// <summary>
///     Representa el validador para el comando <see cref="ProcessJobApplicationCommand" />
/// </summary>
internal sealed class ProcessJobApplicationCommandValidator : AbstractValidator<ProcessJobApplicationCommand>
{
    /// <summary>
    ///     Inicializa una nueva instancia de la clase <see cref="ProcessJobApplicationCommandValidator" />.
    /// </summary>
    public ProcessJobApplicationCommandValidator()
    {
        RuleFor(x => x.JobApplicationId)
            .NotEmpty()
            .WithError(ValidationErrors.ProcessJobApplication.JobApplicationIdIsRequired);

        RuleFor(x => x.State)
            .NotEmpty()
            .WithError(ValidationErrors.ProcessJobApplication.StateIsRequired)
            .Must(state => state is "Accepted" or "Rejected")
            .WithError(ValidationErrors.ProcessJobApplication.InvalidState);
    }
}