using AvBeacon.Domain.Core.Primitives;

namespace AvBeacon.Domain.Core.Errors
{
    /// <summary>Contains the domain errors.</summary>
    public static class DomainErrors
    {
        /// <summary>Contains the user errors.</summary>
        public static class User
        {
            public static Error NotFound =>
                new("User.NotFound", "The user with the specified identifier was not found.");

            public static Error InvalidPermissions =>
                new(
                    "User.InvalidPermissions",
                    "The current user does not have the permissions to perform that operation.");

            public static Error DuplicateEmail => new("User.DuplicateEmail", "The specified email is already in use.");

            public static Error CannotChangePassword =>
                new(
                    "User.CannotChangePassword",
                    "The password cannot be changed to the specified password.");
        }

        /// <summary>Contains the notification errors.</summary>
        public static class Notification
        {
            public static Error AlreadySent =>
                new("Notification.AlreadySent", "The notification has already been sent.");
        }

        /// <summary>Contains the name errors.</summary>
        public static class Name
        {
            public static Error NullOrEmpty => new("Name.NullOrEmpty", "The name is required.");

            public static Error LongerThanAllowed => new("Name.LongerThanAllowed", "The name is longer than allowed.");
        }

        /// <summary>Contains the first name errors.</summary>
        public static class FirstName
        {
            public static Error NullOrEmpty => new("FirstName.NullOrEmpty", "The first name is required.");

            public static Error LongerThanAllowed =>
                new("FirstName.LongerThanAllowed", "The first name is longer than allowed.");
        }

        /// <summary>Contains the last name errors.</summary>
        public static class LastName
        {
            public static Error NullOrEmpty => new("LastName.NullOrEmpty", "The last name is required.");

            public static Error LongerThanAllowed =>
                new("LastName.LongerThanAllowed", "The last name is longer than allowed.");
        }

        /// <summary>Contains the email errors.</summary>
        public static class Email
        {
            public static Error NullOrEmpty => new("Email.NullOrEmpty", "The email is required.");

            public static Error LongerThanAllowed =>
                new("Email.LongerThanAllowed", "The email is longer than allowed.");

            public static Error InvalidFormat => new("Email.InvalidFormat", "The email format is invalid.");
        }

        /// <summary>Contains the password errors.</summary>
        public static class Password
        {
            public static Error NullOrEmpty => new("Password.NullOrEmpty", "The password is required.");

            public static Error TooShort => new("Password.TooShort", "The password is too short.");

            public static Error MissingUppercaseLetter =>
                new(
                    "Password.MissingUppercaseLetter",
                    "The password requires at least one uppercase letter.");

            public static Error MissingLowercaseLetter =>
                new(
                    "Password.MissingLowercaseLetter",
                    "The password requires at least one lowercase letter.");

            public static Error MissingDigit =>
                new(
                    "Password.MissingDigit",
                    "The password requires at least one digit.");

            public static Error MissingNonAlphaNumeric =>
                new(
                    "Password.MissingNonAlphaNumeric",
                    "The password requires at least one non-alphanumeric.");
        }

        /// <summary>Contains general errors.</summary>
        public static class General
        {
            public static Error UnProcessableRequest =>
                new(
                    "General.UnProcessableRequest",
                    "The server could not process the request.");

            public static Error ServerError =>
                new("General.ServerError", "The server encountered an unrecoverable error.");
        }

        /// <summary>Contains the authentication errors.</summary>
        public static class Authentication
        {
            public static Error InvalidEmailOrPassword =>
                new(
                    "Authentication.InvalidEmailOrPassword",
                    "The specified email or password are incorrect.");

            public static Error EmailNotFound =>
                new("Authentication.EmailNotFound", "The specified email was not found.");

            public static Error UserNotFound => new("Authentication.UserNotFound", "The specified user was not found.");

            public static Error InvalidPassword =>
                new("Authentication.InvalidPassword", "The specified password is incorrect.");
        }

        /// <summary>Contains the applicant errors.</summary>
        public static class Applicant
        {
            public static Error InvalidEmailOrPassword =>
                new(
                    "Applicant.InvalidEmailOrPassword",
                    "The specified email or password are incorrect.");

            public static Error NotFound =>
                new("Applicant.NotFound", "The applicant with the specified identifier was not found.");
        }

        /// <summary>Contains the skill errors.</summary>
        public static class Skill
        {
            public static Error NotFound =>
                new("Skill.NotFound", "The skill with the specified identifier was not found.");

            public static Error AlreadyInSkillList =>
                new("Skill.AlreadyInSkillList", "The skill is already in the user's skill list.");
        }

        /// <summary>Contains the education errors.</summary>
        public static class Education
        {
            public static Error InvalidEducationType =>
                new("Education.InvalidEducationType", "The specified education type is invalid.");
        }

        /// <summary>Contains the job offer errors.</summary>
        public static class JobOffer
        {
            public static Error NotFound =>
                new("JobOffer.NotFound", "The job offer with the specified identifier was not found.");
        }

        /// <summary>Contains the job application errors.</summary>
        public static class JobApplication
        {
            public static Error AlreadyExists =>
                new("JobApplication.AlreadyExists", "The job application already exists.");

            public static Error NotFound =>
                new("JobApplication.NotFound", "The job application with the specified identifier was not found.");
        }

        /// <summary>Contains the description errors.</summary>
        public static class Description
        {
            public static Error NullOrEmpty => new("Description.NullOrEmpty", "The description is required.");

            public static Error LongerThanAllowed =>
                new("Description.LongerThanAllowed", "The description is longer than allowed.");
        }
    }
}