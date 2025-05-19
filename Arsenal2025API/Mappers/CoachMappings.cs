using Arsenal2025API.Dtos;
using Arsenal2025API.Models;

namespace Arsenal2025API.Mappers;

public static class CoachMappings
{
    public static Coach ToCoach(this CreateCoach createCoach)
    {
        return new Coach
        {
            Id = Guid.CreateVersion7(),
            Name = createCoach.Name,
            Tenure = createCoach.Tenure,
            CreatedAt = DateTime.UtcNow
        };
    }
}