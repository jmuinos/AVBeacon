namespace AvBeacon.Contracts.Experiences;

/// <summary>
///     Representa la solicitud para crear una experiencia.
/// </summary>
public sealed class CreateExperienceRequest
{
    public Guid ApplicantId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    /// <summary>
    ///     Obtiene o establece la fecha de inicio de la experiencia.
    /// </summary>
    public DateTime? Start { get; set; }

    /// <summary>
    ///     Obtiene o establece la fecha de fin de la experiencia.
    /// </summary>
    public DateTime? End { get; set; }
}