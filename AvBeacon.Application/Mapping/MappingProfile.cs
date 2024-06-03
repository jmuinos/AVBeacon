using AutoMapper;
using AvBeacon.Application.DTOs;
using AvBeacon.Domain.Candidates;

namespace AvBeacon.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile() { CreateMap<Candidate, CandidateDto>().ReverseMap(); }
}