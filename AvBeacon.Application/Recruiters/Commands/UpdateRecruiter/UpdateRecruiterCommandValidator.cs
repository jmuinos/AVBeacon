using FluentValidation;

namespace AvBeacon.Application.Recruiters.Commands.UpdateRecruiter;

public class UpdateRecruiterCommandValidator : AbstractValidator<UpdateRecruiterCommand>
{
    public UpdateRecruiterCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty().When(x => !string.IsNullOrEmpty(x.FirstName));
        RuleFor(x => x.LastName).NotEmpty().When(x => !string.IsNullOrEmpty(x.LastName));
    }
}