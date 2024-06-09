using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.JobOffers.Commands.UpdateJobOffer;

/// <summary>Validador para el comando <see cref="UpdateJobOfferCommand" />.</summary>
public sealed class UpdateJobOfferCommandValidator : AbstractValidator<UpdateJobOfferCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="UpdateJobOfferCommandValidator" /></summary>
    public UpdateJobOfferCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty()
           .WithError(ValidationErrors.UpdateJobOffer.JobOfferIdIsRequired);

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithError(ValidationErrors.UpdateJobOffer.TitleIsRequired)
           .MaximumLength(200)
           .WithError(ValidationErrors.UpdateJobOffer.TitleTooLong);

        RuleFor(x => x.Description)
           .NotEmpty()
           .WithError(ValidationErrors.UpdateJobOffer.DescriptionIsRequired)
           .MaximumLength(500)
           .WithError(ValidationErrors.UpdateJobOffer.DescriptionTooLong);
    }
}