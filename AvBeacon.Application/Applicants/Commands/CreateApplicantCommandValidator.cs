using FluentValidation;

namespace AvBeacon.Application.Applicants.Commands;

public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
{
    public CreateApplicantCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}