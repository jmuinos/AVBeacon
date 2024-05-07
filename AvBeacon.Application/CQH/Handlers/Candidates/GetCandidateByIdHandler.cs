using AutoMapper;
using AvBeacon.Application.CQH.Queries.Candidates;
using AvBeacon.Application.DTOs;
using AvBeacon.Domain.Interfaces;
using MediatR;

namespace AvBeacon.Application.CQH.Handlers.Candidates
{
    public class GetCandidateByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : IRequestHandler<GetCandidateByIdQuery, CandidateDto>
    {
        public async Task<CandidateDto> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await unitOfWork.Candidates.GetByIdAsync(request.Id);
            return mapper.Map<CandidateDto>(candidate);
        }
    }
}