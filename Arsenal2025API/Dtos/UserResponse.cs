using Arsenal2025API.Models;

namespace Arsenal2025API.Dtos;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public SystemRole Role { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}