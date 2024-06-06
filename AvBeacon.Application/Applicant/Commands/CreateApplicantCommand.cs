using MediatR;

namespace AvBeacon.Application.Applicant.Commands
{
    public class CreateApplicantCommand : IRequest<Guid>
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}