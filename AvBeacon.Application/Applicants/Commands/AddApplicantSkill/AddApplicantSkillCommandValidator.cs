using AvBeacon.Application._Core.Abstractions.Extensions;
using AvBeacon.Application._Core.Errors;
using AvBeacon.Application.Authentication.Update;
using FluentValidation;

namespace AvBeacon.Application.Applicants.Commands.AddApplicantSkill;

/// <summary> Represents the <see cref="UpdateUserCommand" /> validator. </summary>
internal sealed class AddApplicantSkillCommandValidator : AbstractValidator<UpdateUserCommand>
{
    /// <summary> Initializes a new instance of the <see cref="AddApplicantSkillCommandValidator" /> class. </summary>
    public AddApplicantSkillCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithError(ValidationErrors.AddApplicantSkill.ApplicantIdIsRequired);
        RuleFor(x => x.UserId).NotEmpty().WithError(ValidationErrors.AddApplicantSkill.SkillIdIsRequired);
    }
}