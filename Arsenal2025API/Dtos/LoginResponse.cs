namespace Arsenal2025API.Dtos;

public record LoginResponse
{
    public required string AccessToken { get; set; }
    public required int ExpiresIn { get; set; }
}