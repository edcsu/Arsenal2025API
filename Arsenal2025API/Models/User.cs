namespace Arsenal2025API.Models;

public class User : BaseModel
{
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required string Email { get; set; }
    public SystemRole Role { get; set; }
    public bool IsActive { get; set; }
}
