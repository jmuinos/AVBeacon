using AvBeacon.Domain._Core.Primitives;

namespace AvBeacon.Application._Core.Errors;

/// <summary> Contiene los errores de validación. </summary>
internal static class ValidationErrors
{
    /// <summary> Contiene los errores de cambio de contraseña. </summary>
    internal static class ChangePassword
    {
        internal static Error PasswordIsRequired =>
            new("ChangePassword.PasswordIsRequired", "La contraseña es obligatoria.");

        internal static Error UserIdIsRequired =>
            new("ChangePassword.UserIdIsRequired", "El ID del usuario es obligatorio.");
    }

    /// <summary> Contiene los errores de creación de habilidades del solicitante. </summary>
    internal static class AddApplicantSkill
    {
        internal static Error ApplicantIdIsRequired =>
            new("AddApplicantSkill.ApplicantIdIsRequired", "El ID del solicitante es obligatorio.");

        internal static Error SkillIdIsRequired =>
            new("AddApplicantSkill.SkillIdIsRequired", "El ID de la habilidad es requerido.");
    }

    /// <summary> Contiene los errores de creación de solicitud de empleo. </summary>
    internal static class CreateJobApplication
    {
        internal static Error ApplicantIdIsRequired =>
            new("CreateJobApplication.ApplicantIdIsRequired", "El ID del solicitante es requerido.");

        internal static Error JobOfferIdIsRequired => new("CreateJobApplication.JobOfferIdIsRequired",
                                                          "El ID de la oferta de trabajo es requerido.");
    }

    /// <summary> Contiene los errores de creación de oferta de trabajo. </summary>
    internal static class CreateJobOffer
    {
        internal static Error DescriptionIsRequired => new("CreateJobOffer.DescriptionIsRequired",
                                                           "La descripción de la oferta de empleo es requerida.");

        internal static Error RecruiterIdIsRequired =>
            new("CreateJobOffer.RecruiterIdIsRequired", "El ID del reclutador es requerido.");

        internal static Error TitleIsRequired =>
            new("CreateJobOffer.TitleIsRequired", "El título de la oferta de empleo es requerido.");
    }

    /// <summary> Contiene los errores de creación de educación. </summary>
    internal static class CreateEducation
    {
        internal static Error ApplicantIdIsRequired => new("CreateEducation.ApplicantIdIsRequired",
                                                           "El identificador del solicitante es obligatorio.");

        internal static Error DescriptionIsRequired =>
            new("CreateEducation.DescriptionIsRequired", "La descripción es obligatoria.");

        internal static Error InvalidEducationType =>
            new("CreateEducation.InvalidEducationType", "El tipo de educación es inválido.");

        internal static Error TitleIsRequired =>
            new("CreateEducation.ApplicantIdIsRequired", "El título de la educación es obligatorio.");
    }

    /// <summary> Contiene los errores de creación de experiencia. </summary>
    internal static class CreateExperience
    {
        internal static Error ApplicantIdIsRequired =>
            new("CreateExperience.ApplicantIdIsRequired", "El ID del solicitante es obligatorio.");

        internal static Error StartMustBeEarlierThanEnd => new("CreateExperience.StartMustBeEarlierThanEnd",
                                                               "La fecha de inicio debe ser anterior a la fecha de finalización.");

        internal static Error TitleIsRequired => new("CreateExperience.TitleIsRequired", "El título es obligatorio.");
    }

    /// <summary> Contiene los errores de inicio de sesión. </summary>
    internal static class Login
    {
        internal static Error EmailIsRequired => new("Login.EmailIsRequired", "El correo electrónico es obligatorio.");
        internal static Error PasswordIsRequired => new("Login.PasswordIsRequired", "La contraseña es obligatoria.");
    }

    /// <summary> Contiene los errores de procesamiento de la solicitud de trabajo. </summary>
    internal static class ProcessJobApplication
    {
        internal static Error InvalidState => new("ProcessJobApplication.InvalidState",
                                                  "El estado de la solicitud de trabajo es inválido. Debe ser 'Accepted' o 'Denied'.");

        internal static Error JobApplicationIdIsRequired => new("ProcessJobApplication.JobApplicationIdIsRequired",
                                                                "El ID de la solicitud de trabajo es requerido.");

        internal static Error StateIsRequired => new("ProcessJobApplication.StateIsRequired",
                                                     "El estado de la solicitud de trabajo es requerido.");
    }

    /// <summary> Contiene los errores de eliminación de oferta de trabajo. </summary>
    internal static class RemoveJobOffer
    {
        internal static Error JobOfferIdIsRequired =>
            new("RemoveJobOffer.JobOfferIdIsRequired", "El ID de la oferta de empleo es requerido.");
    }

    /// <summary> Contiene los errores de actualización de usuario. </summary>
    internal static class UpdateUser
    {
        internal static Error FirstNameIsRequired => new("UpdateUser.FirstNameIsRequired", "El nombre es obligatorio.");
        internal static Error LastNameIsRequired => new("UpdateUser.LastNameIsRequired", "El apellido es obligatorio.");

        internal static Error UserIdIsRequired =>
            new("UpdateUser.UserIdIsRequired", "El ID del usuario es obligatorio.");
    }

    /// <summary> Contiene los errores de actualización de oferta de trabajo. </summary>
    internal static class UpdateJobOffer
    {
        internal static Error DescriptionIsRequired => new("UpdateJobOffer.DescriptionIsRequired",
                                                           "La descripción de la oferta de empleo es requerida.");

        internal static Error JobOfferIdIsRequired =>
            new("UpdateJobOffer.JobOfferIdIsRequired", "El ID de la oferta de empleo es requerido.");

        internal static Error TitleIsRequired =>
            new("UpdateJobOffer.TitleIsRequired", "El título de la oferta de empleo es requerido.");
    }

    /// <summary> Contiene los errores de actualización de educación. </summary>
    internal static class UpdateEducation
    {
        internal static Error ApplicantIdIsRequired => new("UpdateEducation.ApplicantIdIsRequired",
                                                           "El identificador del solicitante es obligatorio.");

        internal static Error EducationIdIsRequired =>
            new("UpdateEducation.EducationIdIsRequired", "El ID de la educación es requerido.");

        internal static Error StartMustBeEarlierThanEnd => new("UpdateEducation.StartMustBeEarlierThanEnd",
                                                               "La fecha de inicio debe ser anterior a la fecha de finalización.");

        internal static Error TitleIsRequired => new("UpdateEducation.TitleIsRequired", "El título es requerido.");
    }

    /// <summary> Contiene los errores de actualización de experiencia. </summary>
    internal static class UpdateExperience
    {
        internal static Error ApplicantIdIsRequired => new("UpdateExperience.ApplicantIdIsRequired",
                                                           "El identificador del solicitante es obligatorio.");

        internal static Error ExperienceIdIsRequired =>
            new("UpdateExperience.ExperienceIdIsRequired", "El ID de la experiencia es requerido.");

        internal static Error StartMustBeEarlierThanEnd => new("UpdateExperience.StartMustBeEarlierThanEnd",
                                                               "La fecha de inicio debe ser anterior a la fecha de finalización.");

        internal static Error TitleIsRequired => new("UpdateExperience.TitleIsRequired", "El título es requerido.");
    }

    /// <summary> Contiene los errores de creación de usuario. </summary>
    internal static class CreateUser
    {
        internal static Error EmailIsRequired =>
            new("CreateUser.EmailIsRequired", "El correo electrónico es obligatorio.");

        internal static Error FirstNameIsRequired =>
            new("CreateUser.FirstNameIsRequired", "El primer nombre es obligatorio.");

        internal static Error LastNameIsRequired => new("CreateUser.LastNameIsRequired", "El apellido es obligatorio.");

        internal static Error PasswordIsRequired =>
            new("CreateUser.PasswordIsRequired", "La contraseña es obligatoria.");
    }
}