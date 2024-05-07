using AvBeacon.Application.CQH.Commands.Candidates;
using AvBeacon.Domain.Interfaces;
using MediatR;

namespace AvBeacon.Application.CQH.Handlers.Candidates
{
    public class UpdateCandidateHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCandidateCommand, bool>
    {
        public async Task<bool> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await unitOfWork.Candidates.GetByIdAsync(request.Id);
            if (candidate == null) return false;

            candidate.FirstName = request.FirstName;
            candidate.LastName = request.LastName;
            candidate.Mail = request.Mail;

            unitOfWork.Candidates.Update(candidate);
            await unitOfWork.CompleteAsync();
            return true;
        }
    }
}