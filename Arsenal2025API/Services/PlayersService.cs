using Arsenal2025API.Data;
using Arsenal2025API.Dtos;
using Arsenal2025API.Mappers;
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

    public async Task<Player> CreateAsync(CreatePlayer createPlayer, 
        CancellationToken cancellationToken = default)
    {
        var player = createPlayer.ToPlayer();
        _context.Players.Add(player);
        await _context.SaveChangesAsync(cancellationToken);
        return player;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var player = await _context.Players.FindAsync([id], 
            cancellationToken: cancellationToken);
        if (player is null)
        {
            _logger.LogError("Player with id {Id} was not found", id);
            return false;
        }
        
        _context.Players.Remove(player);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}