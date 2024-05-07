using AutoMapper;
using AvBeacon.Application.DTOs;
using AvBeacon.Domain.Entities;

namespace AvBeacon.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Candidate, CandidateDto>();
    }
}