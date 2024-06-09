using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using FluentValidation;

namespace AvBeacon.Application.JobOffers.Commands.CreateJobOffer;

/// <summary>Validador para el comando <see cref="CreateJobOfferCommand" />.</summary>
public sealed class CreateJobOfferCommandValidator : AbstractValidator<CreateJobOfferCommand>
{
    /// <summary>Inicializa una nueva instancia de la clase <see cref="CreateJobOfferCommandValidator" />.</summary>
    public CreateJobOfferCommandValidator()
    {
        RuleFor(x => x.RecruiterId)
           .NotEmpty()
           .WithError(ValidationErrors.CreateJobOffer.RecruiterIdIsRequired);

        RuleFor(x => x.Title)
           .NotEmpty()
           .WithError(ValidationErrors.CreateJobOffer.TitleIsRequired)
           .MaximumLength(200)
           .WithError(ValidationErrors.CreateJobOffer.TitleTooLong);

        RuleFor(x => x.Description)
           .NotEmpty()
           .WithError(ValidationErrors.CreateJobOffer.DescriptionIsRequired)
           .MaximumLength(500)
           .WithError(ValidationErrors.CreateJobOffer.DescriptionTooLong);
    }
}