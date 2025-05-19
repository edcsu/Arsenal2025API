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
    public async Task<IActionResult> GetCoachesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to find coaches");
        var coaches = await _coachesService.GetAllCoachesAsync(cancellationToken);
        _logger.LogInformation("Finished trying to find coaches");
        return Ok(coaches);
    }
    
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCoachAsync( Guid id, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to find coach with id: {Id}", id);
        var coach = await _coachesService.FindByIdAsync(id, cancellationToken);
        if (coach is null)
        {
            _logger.LogError("Coach with id: {Id} was not found", id);
            return NotFound();
        }
        _logger.LogInformation("Coach with id: {Id} was not found", id);
        return Ok(coach);
    }
}