using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface IPlayersService
{
    Task<List<Player>> GetAll(CancellationToken cancellationToken = default);
}