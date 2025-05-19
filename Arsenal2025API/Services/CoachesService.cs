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
        var coaches = await _context.Coaches.ToListAsync(cancellationToken);
        return coaches;
    }

    public async Task<Coach?> FindByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var coach = await _context.Coaches.FindAsync([id], 
            cancellationToken: cancellationToken);
        return coach;
    }

    public async Task<Coach> CreateAsync(CreateCoach createCoach, 
        CancellationToken cancellationToken = default)
    {
        var coach = createCoach.ToCoach();
        _context.Coaches.Add(coach);
        await _context.SaveChangesAsync(cancellationToken);
        return coach;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var coach = await _context.Coaches.FindAsync([id], 
            cancellationToken: cancellationToken);
        if (coach is null)
        {
            _logger.LogError("Coach with id {Id} was not found", id);
            return false;
        }
        
        _context.Coaches.Remove(coach);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}