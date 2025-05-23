using System.ComponentModel.DataAnnotations;

namespace Arsenal2025API.Dtos;

public record CreateCoach
{
    [MaxLength(70)]
    [Required]
    public required string Name { get; set; }

    public int TotalTrophies { get; set; }

    [MaxLength(20)]
    [Required]
    public required string Tenure { get; set; }
}