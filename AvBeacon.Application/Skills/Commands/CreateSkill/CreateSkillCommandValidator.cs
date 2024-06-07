using FluentValidation;

namespace AvBeacon.Application.Skills.Commands.CreateSkill;

public class CreateSkillCommandValidator : AbstractValidator<CreateSkillCommand>
{
    public CreateSkillCommandValidator()
    {
        RuleFor(x => x.ApplicantId).NotEmpty().WithMessage("ApplicantId is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.")
                            .MaximumLength(50).WithMessage("Name must not exceed 50 characters.");
    }
}