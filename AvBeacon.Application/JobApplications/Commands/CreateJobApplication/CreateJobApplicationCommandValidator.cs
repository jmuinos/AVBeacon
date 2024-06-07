using FluentValidation;

namespace AvBeacon.Application.JobApplications.Commands.CreateJobApplication;

public class CreateJobApplicationCommandValidator : AbstractValidator<CreateJobApplicationCommand>
{
    public CreateJobApplicationCommandValidator()
    {
        RuleFor(x => x.ApplicantId).NotEmpty();
        RuleFor(x => x.JobOfferId).NotEmpty();
    }
}