namespace AvBeacon.Contracts.JobApplications;

/// <summary> Representa la solicitud para procesar una oferta de trabajo. </summary>
public sealed class JobApplicationRequest
{
    public required Guid JobApplicationId { get; set; }

    /// <summary> Obtiene o establece el nuevo estado de la oferta de trabajo (Accepted/Denied). </summary>
    public required string State { get; set; }
}