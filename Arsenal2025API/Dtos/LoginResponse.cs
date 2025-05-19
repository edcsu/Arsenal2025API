namespace Arsenal2025API.Dtos;

public record LoginResponse
{
    public required string AccessToken { get; set; }
    public required DateTime ExpiresAt { get; set; }
}