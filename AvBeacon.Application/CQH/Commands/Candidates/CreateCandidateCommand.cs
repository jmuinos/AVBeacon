using MediatR;

namespace AvBeacon.Application.CQH.Commands.Candidates;

public class CreateCandidateCommand : IRequest<long>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Mail { get; set; }
}