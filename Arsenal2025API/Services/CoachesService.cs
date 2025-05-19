using Arsenal2025API.Data;
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
        var coach = await _context.Coaches.FindAsync([id], cancellationToken: cancellationToken);
        return coach;
    }
}