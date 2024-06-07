namespace AvBeacon.Domain._Core.Abstractions.Primitives.Result;

/// <summary>Represents a result of some operation, with status information and possibly an error.</summary>
public class Result
{
    /// <summary>Initializes a new instance of the <see cref="Result" /> class with the specified parameters.</summary>
    /// <param name="isSuccess">The flag indicating if the result is successful.</param>
    /// <param name="error">The error.</param>
    protected Result(bool isSuccess, Error error)
    {
        if ((isSuccess && !error.Equals(Error.None)) || (!isSuccess && error.Equals(Error.None)))
            throw new InvalidOperationException();
        IsSuccess = isSuccess;
        Error = error;
    }

    /// <summary>Gets a value indicating whether the result is a success result.</summary>
    public bool IsSuccess { get; }

    /// <summary>Gets a value indicating whether the result is a failure result.</summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>Gets the error.</summary>
    public Error Error { get; }

    public static Result Success() { return new Result(true, Error.None); }

    public static Result<TValue> Success<TValue>(TValue value) { return new Result<TValue>(value, true, Error.None); }

    public static Result<TValue> Create<TValue>(TValue? value, Error error) where TValue : class
    {
        return value is null ? Failure<TValue>(error) : Success(value);
    }

    public static Result Failure(Error error) { return new Result(false, error); }

    public static Result<TValue> Failure<TValue>(Error error) { return new Result<TValue>(default!, false, error); }

    public static Result FirstFailureOrSuccess(params Result[] results)
    {
        return results.FirstOrDefault(result => result.IsFailure) ?? Success();
    }
}