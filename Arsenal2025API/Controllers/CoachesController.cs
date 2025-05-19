using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arsenal2025API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachesController : ControllerBase
{
    private readonly ILogger<CoachesController> _logger;

    public CoachesController(DataService dataService, ILogger<CoachesController> logger)
    {
        DataService = dataService;
        _logger = logger;
    }

    public DataService DataService { get; }

    [HttpGet]
    public List<Coach> GetCoaches()
    {
        return DataService.GetCoaches().ToList();
    }
}