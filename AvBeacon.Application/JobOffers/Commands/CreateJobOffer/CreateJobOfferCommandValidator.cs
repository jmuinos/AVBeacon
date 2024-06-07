using FluentValidation;

namespace AvBeacon.Application.JobOffers.Commands.CreateJobOffer;

public class CreateJobOfferCommandValidator : AbstractValidator<CreateJobOfferCommand>
{
    public CreateJobOfferCommandValidator()
    {
        RuleFor(x => x.RecruiterId).NotEmpty().WithMessage("RecruiterId is required.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.")
                             .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.")
                                   .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
    }
}