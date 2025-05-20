using Arsenal2025API.Dtos;
using Arsenal2025API.Helpers;
using Arsenal2025API.Models;

namespace Arsenal2025API.Mappers;

public static class AuthMappings
{
    public static User ToUser(this CreateUserRequest request)
    {
        return new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = AuthHelpers.HashPassword(request.Password),
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
        };
    }
    
    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse
        {
            Id = user.Id,
            Role = user.Role,
            Username = user.Username,
            Email = user.Email,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
        };
    }
}