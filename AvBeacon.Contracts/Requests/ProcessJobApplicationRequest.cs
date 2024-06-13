namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud para procesar una oferta de trabajo. </summary>
public sealed class ProcessJobApplicationRequest
{
    public required Guid JobApplicationId { get; set; }

    /// <summary> Obtiene o establece el nuevo estado de la oferta de trabajo (Accepted/Denied). </summary>
    public required string State { get; set; }
}