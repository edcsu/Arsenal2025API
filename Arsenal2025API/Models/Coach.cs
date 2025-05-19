using System.ComponentModel.DataAnnotations.Schema;

namespace Arsenal2025API.Models;

public class Coach : BaseModel
{
    [Column(TypeName = "varchar(70)")]
    public required string Name { get; set; }

    public int TotalTrophies { get; set; }

    [Column(TypeName = "varchar(20)")]
    public required string Tenure { get; set; }
}