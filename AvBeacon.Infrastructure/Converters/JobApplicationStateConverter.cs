using AvBeacon.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvBeacon.Infrastructure.Converters;

public class JobApplicationStateConverter() : ValueConverter<JobApplicationState, string>(v => v.Value,
                                                                                          v => JobApplicationState
                                                                                             .FromString(v));