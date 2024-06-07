using FluentValidation;

namespace AvBeacon.Application.Applicants.Commands;

public class UpdateApplicantCommandValidator : AbstractValidator<UpdateApplicantCommand>
{
    public UpdateApplicantCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().When(x => !string.IsNullOrEmpty(x.FirstName));
        RuleFor(x => x.LastName).NotEmpty().When(x => !string.IsNullOrEmpty(x.LastName));
    }
}