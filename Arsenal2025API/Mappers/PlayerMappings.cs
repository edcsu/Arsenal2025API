using Arsenal2025API.Dtos;
using Arsenal2025API.Models;

namespace Arsenal2025API.Mappers;

public static class PlayerMappings
{
    public static Player ToPlayer(this CreatePlayer createPlayer)
    {
        return new Player
        {
            Id = Guid.CreateVersion7(),
            Name = createPlayer.Name,
            DateOfBirth = createPlayer.DateOfBirth,
            Country = createPlayer.Country,
            Position = createPlayer.Position,
            Assists = createPlayer.Assists,
            CleanSheets = createPlayer.CleanSheets,
            GoalsScored = createPlayer.GoalsScored,
            CreatedAt = DateTime.UtcNow
        };
    }
}