using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arsenal2025API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly ILogger<PlayersController> _logger;

    public PlayersController(DataService dataService, ILogger<PlayersController> logger)
    {
        DataService = dataService;
        _logger = logger;
    }

    public DataService DataService { get; }

    [HttpGet]
    public List<Player> GetAllPlayers()
    {
        return DataService.GetPlayers().ToList();
    }
}