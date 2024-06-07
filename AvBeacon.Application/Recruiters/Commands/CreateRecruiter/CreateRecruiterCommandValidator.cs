using FluentValidation;

namespace AvBeacon.Application.Recruiters.Commands.CreateRecruiter;

public class CreateRecruiterCommandValidator : AbstractValidator<CreateRecruiterCommand>
{
    public CreateRecruiterCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
    }
}