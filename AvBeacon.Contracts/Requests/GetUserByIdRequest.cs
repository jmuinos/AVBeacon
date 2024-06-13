namespace AvBeacon.Contracts.Requests;

/// <summary> Representa la solicitud para obtener un usuario por ID. </summary>
public sealed record GetUserByIdRequest
{
    public Guid UserId { get; set; }
}