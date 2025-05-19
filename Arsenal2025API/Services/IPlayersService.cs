using Arsenal2025API.Dtos;
using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface IPlayersService
{
    Task<List<Player>> GetAllPlayersAsync(CancellationToken cancellationToken = default);
    
    Task<Player?> FindByIdAsync(Guid id, 
        CancellationToken cancellationToken = default);
    
    Task<Player> CreateAsync(CreatePlayer createPlayer, 
        CancellationToken cancellationToken = default);
}