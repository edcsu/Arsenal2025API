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
        var response = await _playersService.GetAll();
        return Ok(response);
    }
}