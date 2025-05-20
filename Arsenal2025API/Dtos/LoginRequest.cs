namespace Arsenal2025API.Dtos;

public record LoginRequest
{
    public required string Username { get; set; }
    
    public required string Password { get; set; }
}