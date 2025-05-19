using System.ComponentModel.DataAnnotations;

namespace Arsenal2025API.Dtos;

public class CreateCoach
{
    [MaxLength(70)]
    public required string Name { get; set; }

    public int TotalTrophies { get; set; }

    [MaxLength(20)]
    public required string Tenure { get; set; }
}