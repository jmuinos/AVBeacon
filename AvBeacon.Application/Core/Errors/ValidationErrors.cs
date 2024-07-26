using AvBeacon.Domain.Core.Primitives;

namespace AvBeacon.Application.Core.Errors
{
    /// <summary>
    /// Contains the validation errors.
    /// </summary>
    internal static class ValidationErrors
    {
        /// <summary>
        /// Contains the login errors.
        /// </summary>
        internal static class Login
        {
            internal static Error EmailIsRequired => new Error("Login.EmailIsRequired", "The email is required.");

            internal static Error PasswordIsRequired =>
                new Error("Login.PasswordIsRequired", "The password is required.");
        }

        /// <summary>
        /// Contains the change password errors.
        /// </summary>
        internal static class ChangePassword
        {
            internal static Error UserIdIsRequired =>
                new Error("ChangePassword.UserIdIsRequired", "The user identifier is required.");

            internal static Error PasswordIsRequired =>
                new Error("ChangePassword.PasswordIsRequired", "The password is required.");
        }

        /// <summary>
        /// Contains the user creation errors.
        /// </summary>
        internal static class CreateUser
        {
            internal static Error FirstNameIsRequired =>
                new Error("CreateUser.FirstNameIsRequired", "The first name is required.");

            internal static Error LastNameIsRequired =>
                new Error("CreateUser.LastNameIsRequired", "The last name is required.");

            internal static Error EmailIsRequired => new Error("CreateUser.EmailIsRequired", "The email is required.");

            internal static Error PasswordIsRequired =>
                new Error("CreateUser.PasswordIsRequired", "The password is required.");
        }

        /// <summary>
        /// Contains the send friendship request errors.
        /// </summary>
        internal static class SendFriendshipRequest
        {
            internal static Error UserIdIsRequired =>
                new Error(
                    "SendFriendshipRequest.UserIdIsRequired",
                    "The user identifier is required.");

            internal static Error FriendIdIsRequired =>
                new Error(
                    "SendFriendshipRequest.FriendIdIsRequired",
                    "The friend identifier is required.");
        }

        /// <summary>
        /// Contains the update user errors.
        /// </summary>
        internal static class UpdateUser
        {
            internal static Error UserIdIsRequired =>
                new Error("UpdateUser.UserIdIsRequired", "The user identifier is required.");

            internal static Error FirstNameIsRequired =>
                new Error("UpdateUser.FirstNameIsRequired", "The first name is required.");

            internal static Error LastNameIsRequired =>
                new Error("UpdateUser.LastNameIsRequired", "The last name is required.");
        }

        internal class AddApplicantSkill
        {
            public static Error ApplicantIdIsRequired =>
                new Error("AddApplicantSkill.ApplicantIdIsRequired", "The applicant identifier is required.");

            public static Error SkillIdIsRequired =>
                new Error("AddApplicantSkill.SkillIdIsRequired", "The skill identifier is required.");
        }

        internal class CreateEducation
        {
            public static Error InvalidEducationType =>
                new Error("CreateEducation.InvalidEducationType", "The specified education type is invalid.");

            public static Error TitleIsRequired =>
                new Error("CreateEducation.TitleIsRequired", "The title is required.");

            public static Error DescriptionIsRequired =>
                new Error("CreateEducation.DescriptionIsRequired", "The description is required.");

            public static Error ApplicantIdIsRequired =>
                new Error("CreateEducation.ApplicantIdIsRequired", "The applicant identifier is required.");
        }

        internal class CreateExperience
        {
            public static Error ApplicantIdIsRequired =>
                new Error("CreateExperience.ApplicantIdIsRequired", "The applicant identifier is required.");

            public static Error TitleIsRequired =>
                new Error("CreateExperience.TitleIsRequired", "The title is required.");

            public static Error StartMustBeEarlierThanEnd =>
                new Error("CreateExperience.StartMustBeEarlierThanEnd",
                    "The start date must be earlier than the end date.");
        }

        internal class CreateJobApplication
        {
            public static Error ApplicantIdIsRequired =>
                new Error("CreateJobApplication.ApplicantIdIsRequired", "The applicant identifier is required.");

            public static Error JobOfferIdIsRequired =>
                new Error("CreateJobApplication.JobOfferIdIsRequired", "The job offer identifier is required.");
        }

        internal class ProcessJobApplication
        {
            public static Error JobApplicationIdIsRequired =>
                new Error("ProcessJobApplication.JobApplicationIdIsRequired",
                    "The job application identifier is required.");

            public static Error StateIsRequired =>
                new Error("ProcessJobApplication.StateIsRequired", "The state is required.");

            public static Error InvalidState =>
                new Error("ProcessJobApplication.InvalidState", "The state is invalid.");
        }

        internal class CreateJobOffer
        {
            public static Error TitleIsRequired =>
                new Error("CreateJobOffer.TitleIsRequired", "The title is required.");

            public static Error DescriptionIsRequired =>
                new Error("CreateJobOffer.DescriptionIsRequired", "The description is required.");
        }

        internal class UpdateJobOffer
        {
            public static Error JobOfferIdIsRequired =>
                new Error("UpdateJobOffer.JobOfferIdIsRequired", "The job offer identifier is required.");

            public static Error TitleIsRequired =>
                new Error("UpdateJobOffer.TitleIsRequired", "The title is required.");

            public static Error DescriptionIsRequired =>
                new Error("UpdateJobOffer.DescriptionIsRequired", "The description is required.");
        }
    }
}