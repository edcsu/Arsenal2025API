using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public interface ICoachesService
{
    Task<List<Coach>> GetAll(CancellationToken cancellationToken = default);
}