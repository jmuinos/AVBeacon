namespace AvBeacon.Contracts.JobOffers;

/// <summary> Representa la solicitud para crear una oferta de empleo. </summary>
public sealed class CreateJobOfferRequest
{
    public required Guid RecruiterId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}