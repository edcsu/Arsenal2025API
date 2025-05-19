using System.ComponentModel.DataAnnotations;
using Arsenal2025API.Models;

namespace Arsenal2025API.Dtos;

public record CreatePlayer
{
    [MaxLength(70)]
    public required string Name { get; set; }

    public required DateOnly DateOfBirth { get; set; }

    public required Position Position { get; set; }

    
    [MaxLength(70)]
    public required string Country { get; set; }

    public int CleanSheets { get; set; }

    public int GoalsScored { get; set; }

    public int Assists { get; set; }
}