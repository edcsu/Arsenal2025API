using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arsenal2025API.Controllers;

public class PlayersController : ControllerBase
{
    private readonly ILogger<DataService> _logger;

    public PlayersController(DataService dataService, ILogger<DataService> logger)
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