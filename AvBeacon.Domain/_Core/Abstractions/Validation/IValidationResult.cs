using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Domain._Core.Abstractions.Validation;

public interface IValidationResult
{
    public static readonly Error ValidationError = new("ValidationError", "A validation problem ocurred.");

    Error[] Errors { get; }
}