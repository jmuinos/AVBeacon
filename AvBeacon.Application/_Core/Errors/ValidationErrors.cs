using AvBeacon.Domain._Core.Abstractions.Primitives;

namespace AvBeacon.Application._Core.Errors;

/// <summary>Contains the validation errors.</summary>
internal static class ValidationErrors
{
    /// <summary>Contiene los errores de creación de usuario.</summary>
    internal static class CreateUser
    {
        internal static Error EmailIsRequired => new("CreateUser.EmailIsRequired", "El email es obligatorio.");

        internal static Error InvalidEmailFormat =>
            new("CreateUser.InvalidEmailFormat", "El formato del email es inválido.");

        internal static Error FirstNameIsRequired => new("CreateUser.FirstNameIsRequired", "El nombre es obligatorio.");

        internal static Error FirstNameIsTooLong =>
            new("CreateUser.FirstNameIsTooLong", "El nombre es demasiado largo.");

        internal static Error LastNameIsRequired => new("CreateUser.LastNameIsRequired", "El apellido es obligatorio.");

        internal static Error LastNameIsTooLong =>
            new("CreateUser.LastNameIsTooLong", "El apellido es demasiado largo.");

        internal static Error PasswordIsRequired =>
            new("CreateUser.PasswordIsRequired", "La contraseña es obligatoria.");

        internal static Error PasswordTooShort =>
            new("CreateUser.PasswordTooShort", "La contraseña debe tener al menos 6 caracteres.");
    }

    /// <summary>Contiene los errores de actualización de usuario.</summary>
    internal static class UpdateUser
    {
        internal static Error UserIdIsRequired =>
            new("UpdateUser.UserIdIsRequired", "El ID del usuario es obligatorio.");

        internal static Error FirstNameIsRequired => new("UpdateUser.FirstNameIsRequired", "El nombre es obligatorio.");

        internal static Error FirstNameIsTooLong =>
            new("UpdateUser.FirstNameIsTooLong", "El nombre es demasiado largo.");

        internal static Error LastNameIsRequired => new("UpdateUser.LastNameIsRequired", "El apellido es obligatorio.");

        internal static Error LastNameIsTooLong =>
            new("UpdateUser.LastNameIsTooLong", "El apellido es demasiado largo.");
    }

    /// <summary>Contains the create job application errors.</summary>
    internal static class CreateJobApplication
    {
        /// <summary>El ID del solicitante es requerido.</summary>
        internal static Error ApplicantIdIsRequired =>
            new("CreateJobApplication.ApplicantIdIsRequired", "El ID del solicitante es requerido.");

        /// <summary>El ID de la oferta de trabajo es requerido.</summary>
        internal static Error JobOfferIdIsRequired => new("CreateJobApplication.JobOfferIdIsRequired",
                                                          "El ID de la oferta de trabajo es requerido.");
    }

    /// <summary>Contains the create job offer errors.</summary>
    internal static class CreateJobOffer
    {
        internal static Error RecruiterIdIsRequired =>
            new("CreateJobOffer.RecruiterIdIsRequired", "El ID del reclutador es requerido.");

        internal static Error TitleIsRequired =>
            new("CreateJobOffer.TitleIsRequired", "El título de la oferta de empleo es requerido.");

        internal static Error TitleTooLong => new("CreateJobOffer.TitleTooLong",
                                                  "El título de la oferta de empleo no debe superar los 200 caracteres.");

        internal static Error DescriptionIsRequired => new("CreateJobOffer.DescriptionIsRequired",
                                                           "La descripción de la oferta de empleo es requerida.");

        internal static Error DescriptionTooLong => new("CreateJobOffer.DescriptionTooLong",
                                                        "La descripción de la oferta de empleo no debe superar los 500 caracteres.");
    }

    /// <summary>Contains the update job offer errors.</summary>
    internal static class UpdateJobOffer
    {
        internal static Error JobOfferIdIsRequired =>
            new("UpdateJobOffer.JobOfferIdIsRequired", "El ID de la oferta de empleo es requerido.");

        internal static Error TitleIsRequired =>
            new("UpdateJobOffer.TitleIsRequired", "El título de la oferta de empleo es requerido.");

        internal static Error TitleTooLong => new("UpdateJobOffer.TitleTooLong",
                                                  "El título de la oferta de empleo no debe superar los 200 caracteres.");

        internal static Error DescriptionIsRequired => new("UpdateJobOffer.DescriptionIsRequired",
                                                           "La descripción de la oferta de empleo es requerida.");

        internal static Error DescriptionTooLong => new("UpdateJobOffer.DescriptionTooLong",
                                                        "La descripción de la oferta de empleo no debe superar los 500 caracteres.");
    }

    /// <summary>Contains the create education errors.</summary>
    internal static class CreateEducation
    {
        internal static Error DescriptionIsRequired =>
            new("CreateEducation.DescriptionIsRequired", "La descripción es obligatoria.");

        internal static Error DescriptionTooLong =>
            new("CreateEducation.DescriptionTooLong", "La descripción es demasiado larga.");

        internal static Error StartMustBeEarlierThanEnd => new("CreateEducation.StartMustBeEarlierThanEnd",
                                                               "La fecha de inicio debe ser anterior a la fecha de fin.");

        internal static Error InvalidEducationType =>
            new("CreateEducation.InvalidEducationType", "El tipo de educación es inválido.");

        internal static Error ApplicantIdIsRequired => new("CreateEducation.ApplicantIdIsRequired",
                                                           "El identificador del solicitante es obligatorio.");
    }

    /// <summary>Contains the create experience errors.</summary>
    internal static class CreateExperience
    {
        internal static Error TitleIsRequired => new("CreateExperience.TitleIsRequired", "The title is required.");

        internal static Error ApplicantIdIsRequired =>
            new("CreateExperience.ApplicantIdIsRequired", "El ID del solicitante es obligatorio.");

        internal static Error DescriptionTooLong => new("CreateExperience.DescriptionTooLong",
                                                        "La descripción no puede tener más de 500 caracteres.");

        internal static Error RecruiterNameTooLong => new("CreateExperience.RecruiterNameTooLong",
                                                          "El nombre del reclutador no puede tener más de 150 caracteres.");

        internal static Error StartMustBeEarlierThanEnd => new("CreateExperience.StartMustBeEarlierThanEnd",
                                                               "La fecha de inicio debe ser anterior a la fecha de finalización.");

        internal static Error TitleTooLong =>
            new("CreateExperience.TitleTooLong", "El título no puede tener más de 200 caracteres.");
    }

    /// <summary>Contains the create skill errors. </summary>
    internal static class CreateSkill
    {
        internal static Error TitleIsRequired => new("AddApplicantSkill.TitleIsRequired", "The title is required.");
    }

    /// <summary>
    ///     Contains the update education errors.
    /// </summary>
    internal static class UpdateEducation
    {
        internal static Error EducationIdIsRequired =>
            new("UpdateEducation.EducationIdIsRequired", "The education ID is required.");

        internal static Error DescriptionIsRequired =>
            new("UpdateEducation.DescriptionIsRequired", "The description is required.");
    }

    /// <summary>
    ///     Contains the update experience errors.
    /// </summary>
    internal static class UpdateExperience
    {
        internal static Error ExperienceIdIsRequired =>
            new("UpdateExperience.ExperienceIdIsRequired", "The experience ID is required.");

        internal static Error TitleIsRequired => new("UpdateExperience.TitleIsRequired", "The title is required.");
    }

    /// <summary>
    ///     Contains the update skill errors.
    /// </summary>
    internal static class UpdateSkill
    {
        internal static Error SkillIdIsRequired => new("UpdateSkill.SkillIdIsRequired", "The skill ID is required.");

        internal static Error TitleIsRequired => new("UpdateSkill.TitleIsRequired", "The title is required.");
    }
}