namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud para obtener una habilidad por su identificador. </summary>
public sealed record GetSkillByIdRequest
{
    public Guid SkillId { get; init; }
}