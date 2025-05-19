using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arsenal2025API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly ILogger<PlayersController> _logger;
    private readonly IPlayersService _playersService;
    public PlayersController(ILogger<PlayersController> logger, IPlayersService playersService)
    {
        _logger = logger;
        _playersService = playersService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var response = await _playersService.GetAllPlayersAsync();
        return Ok(response);
    }
    
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCoachAsync( Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to find a player with id: {Id}", id);
        var coach = await _playersService.FindByIdAsync(id, cancellationToken);
        if (coach is null)
        {
            _logger.LogError("Player with id: {Id} was not found", id);
            return NotFound();
        }
        _logger.LogInformation("Player with id: {Id} was found", id);
        return Ok(coach);
    }
}