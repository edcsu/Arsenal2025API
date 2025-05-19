using Arsenal2025API.Data;
using Arsenal2025API.Models;
using Microsoft.EntityFrameworkCore;

namespace Arsenal2025API.Services;

public class PlayersService : IPlayersService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PlayersService> _logger;

    public PlayersService(ApplicationDbContext context, 
        ILogger<PlayersService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Player>> GetAllPlayersAsync(CancellationToken cancellationToken = default)
    {
        var players = await _context.Players.ToListAsync(cancellationToken);
        return players;
    }

    public async Task<Player?> FindByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var player = await _context.Players.FindAsync([id], cancellationToken: cancellationToken);
        return player;
    }
}