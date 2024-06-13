namespace AvBeacon.Contracts.Responses;

/// <summary> Representa la respuesta de una oferta de trabajo. </summary>
public sealed class JobOfferResponse
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public Guid RecruiterId { get; set; }
}