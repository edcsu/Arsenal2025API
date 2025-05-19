using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface ICoachesService
{
    Task<List<Coach>> GetAllCoachesAsync(CancellationToken cancellationToken = default);
    
    Task<Coach?> FindByIdAsync(Guid id, 
    CancellationToken cancellationToken = default);
}