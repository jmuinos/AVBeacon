namespace AvBeacon.Contracts.Responses;

/// <summary> Representa la respuesta de la solicitud de trabajo. </summary>
public sealed class JobApplicationResponse
{
    public Guid Id { get; init; }
    public Guid JobOfferId { get; init; }
    public Guid ApplicantId { get; init; }
    public required string State { get; init; }
    public required string JobOfferTitle { get; init; }
}