namespace AvBeacon.Contracts.Educations;

/// <summary>
///     Representa la solicitud para crear una educación.
/// </summary>
public sealed class CreateEducationRequest
{
    public int EducationType { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required Guid ApplicantId { get; set; }
}