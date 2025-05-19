using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arsenal2025API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoachesController : ControllerBase
{
    private readonly ILogger<CoachesController> _logger;
    private readonly ICoachesService _coachesService;

    public CoachesController(ILogger<CoachesController> logger, 
        ICoachesService coachesService)
    {
        _logger = logger;
        _coachesService = coachesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCoaches()
    {
        var coaches = await _coachesService.GetAll();
        return Ok(coaches);
    }
}