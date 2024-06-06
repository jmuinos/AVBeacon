using MediatR;

namespace AvBeacon.Application.Applicant.Commands
{
    public class UpdateApplicantCommand : IRequest
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}