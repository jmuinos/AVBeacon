using AutoMapper;
using AvBeacon.Application.DTOs;
using AvBeacon.Domain.Applicants;

namespace AvBeacon.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Applicant, ApplicantDto>().ReverseMap();
    }
}