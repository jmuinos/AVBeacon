using AutoMapper;
using AvBeacon.Application.Candidates.Dto;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidateDto>().ReverseMap();
    }
}