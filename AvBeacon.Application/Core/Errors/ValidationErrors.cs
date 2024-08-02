using AvBeacon.Domain.Core.Primitives;

namespace AvBeacon.Application.Core.Errors;

/// <summary>
///     Contains the validation errors.
/// </summary>
internal static class ValidationErrors
{
    /// <summary>
    ///     Contains the login errors.
    /// </summary>
    internal static class Login
    {
        internal static Error EmailIsRequired => new("Login.EmailIsRequired", "The email is required.");

        internal static Error PasswordIsRequired => new("Login.PasswordIsRequired", "The password is required.");
    }

    /// <summary>
    ///     Contains the change password errors.
    /// </summary>
    internal static class ChangePassword
    {
        internal static Error UserIdIsRequired =>
            new("ChangePassword.UserIdIsRequired", "The user identifier is required.");

        internal static Error PasswordIsRequired =>
            new("ChangePassword.PasswordIsRequired", "The password is required.");
    }

    /// <summary>
    ///     Contains the user creation errors.
    /// </summary>
    internal static class CreateUser
    {
        internal static Error FirstNameIsRequired =>
            new("CreateUser.FirstNameIsRequired", "The first name is required.");

        internal static Error LastNameIsRequired => new("CreateUser.LastNameIsRequired", "The last name is required.");

        internal static Error EmailIsRequired => new("CreateUser.EmailIsRequired", "The email is required.");

        internal static Error PasswordIsRequired => new("CreateUser.PasswordIsRequired", "The password is required.");
    }

    /// <summary>
    ///     Contains the send friendship request errors.
    /// </summary>
    internal static class SendFriendshipRequest
    {
        internal static Error UserIdIsRequired =>
            new(
                "SendFriendshipRequest.UserIdIsRequired",
                "The user identifier is required.");

        internal static Error FriendIdIsRequired =>
            new(
                "SendFriendshipRequest.FriendIdIsRequired",
                "The friend identifier is required.");
    }

    /// <summary>
    ///     Contains the update user errors.
    /// </summary>
    internal static class UpdateUser
    {
        internal static Error UserIdIsRequired =>
            new("UpdateUser.UserIdIsRequired", "The user identifier is required.");

        internal static Error FirstNameIsRequired =>
            new("UpdateUser.FirstNameIsRequired", "The first name is required.");

        internal static Error LastNameIsRequired => new("UpdateUser.LastNameIsRequired", "The last name is required.");
    }

    internal class AddApplicantSkill
    {
        public static Error ApplicantIdIsRequired =>
            new("AddApplicantSkill.ApplicantIdIsRequired", "The applicant identifier is required.");

        public static Error SkillIdIsRequired =>
            new("AddApplicantSkill.SkillIdIsRequired", "The skill identifier is required.");
    }

    internal class CreateEducation
    {
        public static Error InvalidEducationType =>
            new("CreateEducation.InvalidEducationType", "The specified education type is invalid.");

        public static Error TitleIsRequired => new("CreateEducation.TitleIsRequired", "The title is required.");

        public static Error DescriptionIsRequired =>
            new("CreateEducation.DescriptionIsRequired", "The description is required.");

        public static Error ApplicantIdIsRequired =>
            new("CreateEducation.ApplicantIdIsRequired", "The applicant identifier is required.");
    }

    internal class CreateExperience
    {
        public static Error ApplicantIdIsRequired =>
            new("CreateExperience.ApplicantIdIsRequired", "The applicant identifier is required.");

        public static Error TitleIsRequired => new("CreateExperience.TitleIsRequired", "The title is required.");

        public static Error StartMustBeEarlierThanEnd =>
            new("CreateExperience.StartMustBeEarlierThanEnd",
                "The start date must be earlier than the end date.");
    }

    internal class CreateJobApplication
    {
        public static Error ApplicantIdIsRequired =>
            new("CreateJobApplication.ApplicantIdIsRequired", "The applicant identifier is required.");

        public static Error JobOfferIdIsRequired =>
            new("CreateJobApplication.JobOfferIdIsRequired", "The job offer identifier is required.");
    }

    internal class ProcessJobApplication
    {
        public static Error JobApplicationIdIsRequired =>
            new("ProcessJobApplication.JobApplicationIdIsRequired",
                "The job application identifier is required.");

        public static Error StateIsRequired => new("ProcessJobApplication.StateIsRequired", "The state is required.");

        public static Error InvalidState => new("ProcessJobApplication.InvalidState", "The state is invalid.");
    }

    internal class CreateJobOffer
    {
        public static Error TitleIsRequired => new("CreateJobOffer.TitleIsRequired", "The title is required.");

        public static Error DescriptionIsRequired =>
            new("CreateJobOffer.DescriptionIsRequired", "The description is required.");
    }

    internal class UpdateJobOffer
    {
        public static Error JobOfferIdIsRequired =>
            new("UpdateJobOffer.JobOfferIdIsRequired", "The job offer identifier is required.");

        public static Error TitleIsRequired => new("UpdateJobOffer.TitleIsRequired", "The title is required.");

        public static Error DescriptionIsRequired =>
            new("UpdateJobOffer.DescriptionIsRequired", "The description is required.");
    }
}