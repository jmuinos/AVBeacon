using FluentValidation;

namespace AvBeacon.Application.JobApplications.Commands.UpdateJobApplication;

public class UpdateJobApplicationStateCommandValidator : AbstractValidator<UpdateJobApplicationStateCommand>
{
    public UpdateJobApplicationStateCommandValidator()
    {
        RuleFor(x => x.JobApplicationId).NotEmpty();
        RuleFor(x => x.State).NotEmpty().Must(BeAValidState);

        bool BeAValidState(string state) { return state is "Sent" or "Accepted" or "Denied"; }
    }
}