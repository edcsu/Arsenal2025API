using System.Net.Mime;
using Arsenal2025API.Dtos;
using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

namespace Arsenal2025API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
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
    [ProducesResponseType(typeof(List<Coach>), StatusCodes.Status200OK,MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Returns Arsenal men's coaches")]
    [EndpointDescription("Returns stats of all Arsenal men's coaches")]
    [Stability(Stability.Stable)]
    public async Task<IActionResult> GetCoachesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to find coaches");
        var coaches = await _coachesService.GetAllCoachesAsync(cancellationToken);
        _logger.LogInformation("Finished trying to find coaches");
        return Ok(coaches);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Coach), StatusCodes.Status200OK,MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Returns a men's coach stats")]
    [EndpointDescription("Returns stats of a men's coach")]
    [Stability(Stability.Stable)]
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
    [Authorize(Roles = "Admin, Supervisor")]
    [Stability(Stability.Stable)]
    [ProducesResponseType(typeof(Coach),StatusCodes.Status201Created, MediaTypeNames.Application.Json)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Create a men's coach stats")]
    [EndpointDescription("Create stats of an Arsenal men's coach")]
    public async Task<IActionResult> CreateCoachAsync(CreateCoach createCoach, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Trying to create a coach with: {TotalTrophies} trophies", createCoach.TotalTrophies);
        var coach = await _coachesService.CreateAsync(createCoach, cancellationToken);
        
        _logger.LogInformation("Coach with id: {Id} was created", coach.Id);
        return Ok(coach);
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin, Supervisor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Remove stats of a men's coach")]
    [EndpointDescription("Remove stats of an Arsenal men's coach")]
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