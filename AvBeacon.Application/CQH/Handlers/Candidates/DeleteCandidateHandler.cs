using MediatR;
using System.Threading.Tasks;
using System.Threading;
using AvBeacon.Application.CQH.Commands.Candidates;
using AvBeacon.Domain.Interfaces;

namespace AvBeacon.Application.CQH.Handlers.Candidates
{
    public class DeleteCandidateHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCandidateCommand, bool>
    {
        public async Task<bool> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await unitOfWork.Candidates.GetByIdAsync(request.Id);
            if (candidate == null) return false;

            unitOfWork.Candidates.Delete(candidate);
            await unitOfWork.CompleteAsync();
            return true;
        }
    }
}
