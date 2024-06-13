namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud para crear una solicitud de empleo. </summary>
public sealed record CreateJobApplicationRequest
{
    public required Guid ApplicantId { get; set; }
    public required Guid JobOfferId { get; set; }
}