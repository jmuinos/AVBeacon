using AvBeacon.Application.CQH.Commands.Candidates;
using AvBeacon.Domain.Entities;
using AvBeacon.Domain.Interfaces;
using MediatR;

namespace AvBeacon.Application.CQH.Handlers.Candidates;

public class CreateCandidateHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCandidateCommand, long>
{
    public async Task<long> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var candidate = new Candidate
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Mail = request.Mail
        };

        await unitOfWork.Candidates.AddAsync(candidate);
        await unitOfWork.CompleteAsync();

        return candidate.Id;
    }
}