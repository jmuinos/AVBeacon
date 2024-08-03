using AvBeacon.Domain._Core.Primitives;

namespace AvBeacon.Domain.Users.Applicants.JobApplications;

/// <summary>
///     Represents the job application state enumeration.
/// </summary>
public sealed class JobApplicationState : Enumeration<JobApplicationState>
{
    public static readonly JobApplicationState Sent = new(0, "Sent");
    public static readonly JobApplicationState Accepted = new(1, "Accepted");
    public static readonly JobApplicationState Rejected = new(2, "Rejected");

    /// <summary>
    ///     Initializes a new instance of the <see cref="JobApplicationState" /> class.
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <param name="name"> The name. </param>
    private JobApplicationState(int value, string name)
        : base(value, name) { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="JobApplicationState" /> class.
    /// </summary>
    /// <param name="value"> The value. </param>
    /// <remarks> Required by EF Core. </remarks>
    private JobApplicationState(int value) : base(value, FromValue(value).Value.Name) { }

    public static JobApplicationState FromString(string value)
    {
        var jobApplicationState = List.FirstOrDefault(state => state.Name == value);
        if (jobApplicationState == null)
            throw new ArgumentException($"Invalid value: {value}", nameof(value));

        return jobApplicationState;
    }

    public static bool TryFromString(string value, out JobApplicationState? jobApplicationState)
    {
        jobApplicationState = List.FirstOrDefault(state => state.Name == value);
        return jobApplicationState != null;
    }
}