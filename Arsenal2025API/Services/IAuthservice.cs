using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface IAuthservice
{
    Task<User?> FindUserByUsername(string username,
        CancellationToken cancellationToken = default);
}