using AvBeacon.Domain.Users;

namespace AvBeacon.Application.Extensions;

public static class EducationTypeEnumExtensions
{
    public static string ToFriendlyString(this EducationType educationType)
    {
        return educationType switch
        {
            EducationType.Ninguna => "No especificada",
            EducationType.FormaciónProfesional => "Formación Profesional",
            EducationType.GradoUniversitario => "Grado Universitario",
            EducationType.Master => "Máster",
            EducationType.Otra => "Otros",
            _ => throw new ArgumentOutOfRangeException(nameof(educationType), educationType, null)
        };
    }
}