using AvBeacon.Domain.ValueObjects;
using FluentValidation;

namespace AvBeacon.Application.Educations.Commands;

public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
{
    public CreateEducationCommandValidator()
    {
        RuleFor(x => x.Description)
           .NotEmpty()
           .MaximumLength(200);

        RuleFor(x => x.Start)
           .LessThanOrEqualTo(x => x.End)
           .WithMessage("The start date must be earlier than the end date.");

        RuleFor(x => x.EducationType)
           .Must(BeAValidEducationType)
           .WithMessage("Invalid education type.");
    }

    private static bool BeAValidEducationType(EducationType educationType)
    {
        return educationType.Equals(EducationType.ObligatoryStudies) ||
               educationType.Equals(EducationType.SuperiorStudies) ||
               educationType.Equals(EducationType.MasterStudies) ||
               educationType.Equals(EducationType.OtherStudies);
    }
}