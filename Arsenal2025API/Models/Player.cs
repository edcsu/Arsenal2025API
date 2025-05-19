using System.ComponentModel.DataAnnotations.Schema;

namespace Arsenal2025API.Models;

public class Player : BaseModel
{
    [Column(TypeName = "varchar(70)")]
    public required string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public required Position Position { get; set; }

    
    [Column(TypeName = "varchar(70)")]
    public required string Country { get; set; }

    public int CleanSheets { get; set; }

    public int GoalsScored { get; set; }

    public int Assists { get; set; }
}