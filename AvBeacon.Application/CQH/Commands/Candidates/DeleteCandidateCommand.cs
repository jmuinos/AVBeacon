using MediatR;

namespace AvBeacon.Application.CQH.Commands.Candidates
{
    public class DeleteCandidateCommand(long id) : IRequest<bool>
    {
        public long Id { get; } = id;
    }
}