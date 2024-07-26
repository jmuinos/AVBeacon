namespace AvBeacon.Domain.Core.Primitives.Result
{
    /// <summary>Represents the result of some operation, with status information and possibly a value and an error.</summary>
    /// <typeparam name="TValue">The result value type.</typeparam>
    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        /// <summary>Initializes a new instance of the <see cref="Result{TValue}" /> class with the specified parameters.</summary>
        /// <param name="value">The result value.</param>
        /// <param name="isSuccess">The flag indicating if the result is successful.</param>
        /// <param name="error">The error.</param>
        protected internal Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            if (isSuccess && value is null)
                throw new ArgumentNullException(nameof(value), "Successful result must have a value.");
            
            _value = value;
        }

        /// <summary>Gets the result value if the result is successful, otherwise throws an exception.</summary>
        /// <returns>The result value if the result is successful.</returns>
        /// <exception cref="InvalidOperationException">When <see cref="Result.IsFailure" /> is true.</exception>
        public TValue Value =>
            IsSuccess
                ? _value!
                : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

        public static implicit operator Result<TValue>(TValue value) => Success(value);

        /// <summary>Returns a success <see cref="Result{TValue}" /> with the specified value.</summary>
        /// <param name="value">The result value.</param>
        /// <returns>A new instance of <see cref="Result{TValue}" /> with the success flag set.</returns>
        private static Result<TValue> Success(TValue value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            return new Result<TValue>(value, true, Error.None);
        }
    }
}
