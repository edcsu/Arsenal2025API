using Arsenal2025API.Dtos;
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
    public async Task<IActionResult> GetCoachAsync( Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to find a coach with id: {Id}", id);
        var coach = await _coachesService.FindByIdAsync(id, cancellationToken);
        if (coach is null)
        {
            _logger.LogError("Coach with id: {Id} was not found", id);
            return NotFound();
        }
        _logger.LogInformation("Coach with id: {Id} was found", id);
        return Ok(coach);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCoachAsync(CreateCoach createCoach, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to create a coach with: {TotalTrophies} trophies", createCoach.TotalTrophies);
        var coach = await _coachesService.CreateAsync(createCoach, cancellationToken);
        
        _logger.LogInformation("Coach with id: {Id} was created", coach.Id);
        return Ok(coach);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCoachAsync( Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to delete a coach with id: {Id}", id);
        var coach = await _coachesService.DeleteByIdAsync(id, cancellationToken);
        if (coach is false)
        {
            _logger.LogError("Coach with id: {Id} was not deleted", id);
            return NotFound();
        }
        _logger.LogInformation("Coach with id: {Id} was deleted", id);
        return Ok();
    }
}