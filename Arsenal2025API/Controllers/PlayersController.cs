using System.Net.Mime;
using Arsenal2025API.Dtos;
using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

namespace Arsenal2025API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[ApiVersion(1)]
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
    [ProducesResponseType(typeof(List<Coach>), StatusCodes.Status200OK,MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Returns Arsenal men's players")]
    [EndpointDescription("Returns details of all Arsenal men'splayers")]
    [Stability(Stability.Stable)]
    public async Task<IActionResult> GetAllPlayers()
    {
        var response = await _playersService.GetAllPlayersAsync();
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Coach), StatusCodes.Status200OK,MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Returns a player stats")]
    [EndpointDescription("Returns stats of an Arsenal men's player")]
    public async Task<IActionResult> GetCoachAsync( Guid id, 
        CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
        {
            _logger.LogError("Invalid player ID: {Id}", id);
            return BadRequest("Invalid player ID");
        }
        
        _logger.LogInformation("Trying to find a player with id: {Id}", id);
        var player = await _playersService.FindByIdAsync(id, cancellationToken);
        if (player is null)
        {
            _logger.LogError("Player with id: {Id} was not found", id);
            return NotFound();
        }
        _logger.LogInformation("Player with id: {Id} was found", id);
        return Ok(player);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin, Supervisor")]
    [ProducesResponseType(typeof(Player),StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Create a player stats")]
    [EndpointDescription("Create stats of an Arsenal men's player")]
    public async Task<IActionResult> CreatePlayerAsync(CreatePlayer createPlayer, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to create a men's player from: {Country}", createPlayer.Country);
        var player = await _playersService.CreateAsync(createPlayer, cancellationToken);
        
        _logger.LogInformation("Player with id: {Id} was created", player.Id);
        return Ok(player);
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin, Supervisor")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Delete stats of a player")]
    [EndpointDescription("Delete stats of an Arsenal men's player")]
    public async Task<IActionResult> DeletePlayerAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        if (id == Guid.Empty)
        {
            _logger.LogError("Invalid player ID: {Id}", id);
            return BadRequest("Invalid player ID");
        }

        _logger.LogInformation("Attempting to delete player with ID: {Id}", id);
        
        var isPlayerDeleted = await _playersService.DeleteByIdAsync(id, cancellationToken);
        if (!isPlayerDeleted)
        {
            _logger.LogError("Failed to delete player with ID: {Id}", id);
            return NotFound($"Player with ID {id} not found");
        }
        
        _logger.LogInformation("Successfully deleted player with ID: {Id}", id);
        return NoContent();
    }
}