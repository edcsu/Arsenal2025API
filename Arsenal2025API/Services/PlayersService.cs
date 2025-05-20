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
        _logger.LogInformation("Retrieving all players");
        var players = await _context.Players.ToListAsync(cancellationToken);
        _logger.LogInformation("Retrieved {Count} players", players.Count);
        return players;
    }

    public async Task<Player?> FindByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Finding player with id {Id}", id);
        var player = await _context.Players.FindAsync([id], cancellationToken: cancellationToken);
        if (player is null)
        {
            _logger.LogWarning("Player with id {Id} was not found", id);
        }
        else
        {
            _logger.LogInformation("Found player {Id}: {Name}", id, player.Name);
        }
        return player;
    }

    public async Task<Player> CreateAsync(CreatePlayer createPlayer, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating new player with name {Name}", createPlayer.Name);
        var player = createPlayer.ToPlayer();
        _context.Players.Add(player);
        
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Successfully created player with id {Id}", player.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create player with name {Name}", createPlayer.Name);
            throw;
        }
        
        return player;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Attempting to delete player with id {Id}", id);
        var player = await _context.Players.FindAsync([id], 
            cancellationToken: cancellationToken);
        if (player is null)
        {
            _logger.LogError("Player with id {Id} was not found", id);
            return false;
        }
        
        _context.Players.Remove(player);
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Successfully deleted player {Id}", id);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete player with id {Id}", id);
            throw;
        }
    }
}