using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvBeacon.Infrastructure.Converters;

public class EducationTypeConverter() : ValueConverter<EducationType, string>(v => v.Value,
                                                                              v => EducationType.FromString(v));