using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.WebApi.Errors;

public class ApiErrorResponse(IReadOnlyCollection<Error> errors)
{
    public IReadOnlyCollection<Error> Errors { get; } = errors;
}