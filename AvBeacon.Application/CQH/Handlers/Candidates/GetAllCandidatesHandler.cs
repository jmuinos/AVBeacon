// GetAllCandidatesHandler.cs

using AutoMapper;
using AvBeacon.Application.CQH.Queries.Candidates;
using AvBeacon.Application.DTOs;
using AvBeacon.Domain.Interfaces;
using MediatR;

namespace AvBeacon.Application.CQH.Handlers.Candidates
{
    public class GetAllCandidatesHandler : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCandidatesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidatesQuery request, CancellationToken cancellationToken)
        {
            var candidates = await _unitOfWork.Candidates.GetAllAsync();
            return _mapper.Map<IEnumerable<CandidateDto>>(candidates);
        }
    }
}

public class GetAllCandidatesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<GetAllCandidatesQuery, IEnumerable<CandidateDto>>
{
    public async Task<IEnumerable<CandidateDto>> Handle(GetAllCandidatesQuery request,
        CancellationToken cancellationToken)
    {
        var candidates = await unitOfWork.Candidates.GetAllAsync();
        return mapper.Map<IEnumerable<CandidateDto>>(candidates);
    }
}