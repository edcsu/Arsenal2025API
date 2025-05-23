using System.ComponentModel;

namespace Arsenal2025API.Dtos;

public record LoginRequest
{
    [Description("The username of the user")]
    public required string Username { get; set; }
    
    [Description("The password of the user")]
    public required string Password { get; set; }
}