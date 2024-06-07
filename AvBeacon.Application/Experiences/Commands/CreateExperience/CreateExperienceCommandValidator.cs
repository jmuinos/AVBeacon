using FluentValidation;

namespace AvBeacon.Application.Experiences.Commands.CreateExperience;

public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
{
    public CreateExperienceCommandValidator()
    {
        RuleFor(x => x.ApplicantId).NotEmpty().WithMessage("ApplicantId is required.");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.")
                             .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
        RuleFor(x => x.RecruiterName).MaximumLength(100).WithMessage("RecruiterName must not exceed 100 characters.");
        RuleFor(x => x.Start).LessThan(x => x.End).When(x => x.Start.HasValue && x.End.HasValue)
                             .WithMessage("Start date must be earlier than End date.");
    }
}