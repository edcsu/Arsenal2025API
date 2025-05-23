using System.ComponentModel;

namespace Arsenal2025API.Dtos;

public record LoginResponse
{
    public required string AccessToken { get; init; }
    
    [Description("The expiration time in minutes")]
    public required int ExpiresIn { get; init; }
}