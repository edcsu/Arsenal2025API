using Arsenal2025API.Dtos;
using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface ICoachesService
{
    Task<List<Coach>> GetAllCoachesAsync(CancellationToken cancellationToken = default);
    
    Task<Coach?> FindByIdAsync(Guid id, 
    CancellationToken cancellationToken = default);
    
    Task<Coach> CreateAsync(CreateCoach createCoach, 
        CancellationToken cancellationToken = default);
    
    Task<bool> DeleteByIdAsync(Guid id, 
        CancellationToken cancellationToken = default);
}