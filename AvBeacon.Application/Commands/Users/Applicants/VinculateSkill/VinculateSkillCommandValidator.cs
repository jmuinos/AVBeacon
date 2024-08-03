using AvBeacon.Application._Core.Errors;
using AvBeacon.Application._Core.Extensions;
using AvBeacon.Application.Commands.Users.Shared.UpdateUser;
using FluentValidation;

namespace AvBeacon.Application.Commands.Users.Applicants.VinculateSkill;

/// <summary>
///     Represents the <see cref="UpdateUserCommand" /> validator.
/// </summary>
internal sealed class VinculateSkillCommandValidator : AbstractValidator<UpdateUserCommand>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="VinculateSkillCommandValidator" /> class.
    /// </summary>
    public VinculateSkillCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithError(ValidationErrors.AddApplicantSkill.ApplicantIdIsRequired);
        RuleFor(x => x.UserId).NotEmpty().WithError(ValidationErrors.AddApplicantSkill.SkillIdIsRequired);
    }
}