using AvBeacon.Application.DTOs;
using MediatR;

namespace AvBeacon.Application.CQH.Queries.Candidates;

public class GetAllCandidatesQuery : IRequest<IEnumerable<CandidateDto>>;