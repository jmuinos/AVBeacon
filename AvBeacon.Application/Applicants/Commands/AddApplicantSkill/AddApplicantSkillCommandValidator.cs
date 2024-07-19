using AvBeacon.Application.Authentication.Update;
using AvBeacon.Application.Core.Errors;
using AvBeacon.Application.Core.Extensions;
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