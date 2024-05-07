using AvBeacon.Application.DTOs;
using MediatR;

namespace AvBeacon.Application.CQH.Queries.Candidates
{
    public class GetCandidateByIdQuery(long id) : IRequest<CandidateDto>
    {
        public long Id { get; } = id;
    }
}