using FluentValidation;

namespace AvBeacon.Application.Applicants.Commands;

public class AddApplicantSkillCommandValidator : AbstractValidator<AddApplicantSkillCommand>
{
    public AddApplicantSkillCommandValidator()
    {
        RuleFor(command => command.ApplicantId)
           .NotEmpty().WithMessage("ApplicantId is required.")
           .Must(BeAValidGuid).WithMessage("ApplicantId must be a valid GUID.");

        RuleFor(command => command.SkillId)
           .NotEmpty().WithMessage("SkillId is required.")
           .Must(BeAValidGuid).WithMessage("SkillId must be a valid GUID.");
    }

    private bool BeAValidGuid(Guid id) { return id != Guid.Empty; }
}