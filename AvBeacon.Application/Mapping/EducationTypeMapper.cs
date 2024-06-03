using AvBeacon.Application.DTOs;
using AvBeacon.Application.Extensions;
using AvBeacon.Domain.Users;

namespace AvBeacon.Application.Mapping;

public static class EducationTypeMapper
{
    public static EducationTypeDto ToDto(this EducationType educationType)
    {
        return new EducationTypeDto
        {
            Id = (int)educationType,
            Name = educationType.ToFriendlyString()
        };
    }

    public static IEnumerable<EducationTypeDto> ToDtoList()
    {
        return Enum.GetValues(typeof(EducationType))
                   .Cast<EducationType>()
                   .Select(e => e.ToDto())
                   .ToList();
    }
}