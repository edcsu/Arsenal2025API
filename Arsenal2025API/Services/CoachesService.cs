using Arsenal2025API.Data;
using Arsenal2025API.Dtos;
using Arsenal2025API.Mappers;
using Arsenal2025API.Models;
using Microsoft.EntityFrameworkCore;

namespace Arsenal2025API.Services;

public class CoachesService : ICoachesService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CoachesService> _logger;

    public CoachesService(ApplicationDbContext context, 
        ILogger<CoachesService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<Coach>> GetAllCoachesAsync(CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Retrieving all coaches");
        var coaches = await _context.Coaches.ToListAsync(cancellationToken);
        _logger.LogInformation("Retrieved {Count} coaches", coaches.Count);
        return coaches;
    }

    public async Task<Coach?> FindByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Searching for coach with ID: {Id}", id);
        var coach = await _context.Coaches.FindAsync([id], 
            cancellationToken: cancellationToken);
        
        if (coach is null)
        {
            _logger.LogWarning("Coach with ID {Id} was not found", id);
        }
        else
        {
            _logger.LogInformation("Found coach: {Id}", id);
        }
        
        return coach;
    }

    public async Task<Coach> CreateAsync(CreateCoach createCoach, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating new coach");
        try
        {
            var coach = createCoach.ToCoach();
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Successfully created coach with ID: {Id}", coach.Id);
            return coach;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create coach");
            throw;
        }
    }

    public async Task<bool> DeleteByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Attempting to delete coach with ID: {Id}", id);
        var coach = await _context.Coaches.FindAsync([id], 
            cancellationToken: cancellationToken);
        if (coach is null)
        {
            _logger.LogError("Coach with ID {Id} was not found", id);
            return false;
        }
        
        try
        {
            _context.Coaches.Remove(coach);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Successfully deleted coach with ID: {Id}", id);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete coach with ID: {Id}", id);
            throw;
        }
    }
}