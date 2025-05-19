using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface IAuthService
{
    Task<User?> FindUserByUsername(string username,
        CancellationToken cancellationToken = default);
}