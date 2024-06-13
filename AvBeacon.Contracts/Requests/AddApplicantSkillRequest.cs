namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud para crear una habilidad de solicitante. </summary>
public sealed record AddApplicantSkillRequest
{
    public Guid ApplicantId { get; set; }
    public Guid SkillId { get; set; }
}