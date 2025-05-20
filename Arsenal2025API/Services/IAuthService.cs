using Arsenal2025API.Dtos;
using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface IAuthService
{
    Task<User?> FindUserByUsernameAsync(string username,
        CancellationToken cancellationToken = default);
    
    Task<User?> FindUserByEmailAsync(string email,
        CancellationToken cancellationToken = default);
    
    Task<User> CreateUserAsync(CreateUserRequest request,
        CancellationToken cancellationToken = default);
    
    Task<User?> FindUserByIdAsync(Guid id,
        CancellationToken cancellationToken = default);
}