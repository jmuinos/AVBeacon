using AvBeacon.Application.DTOs;
using MediatR;

namespace AvBeacon.Application.CQH.Commands.Candidates
{
    public class UpdateCandidateCommand : IRequest<CandidateDto>, IRequest<bool>
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mail { get; set; }
    }
}