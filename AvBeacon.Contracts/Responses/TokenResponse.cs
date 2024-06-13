namespace AvBeacon.Contracts.Responses;

/// <summary> Representa la respuesta del token. </summary>
public sealed class TokenResponse
{
    public TokenResponse(string token) { Token = token; }
    public string Token { get; set; }
}