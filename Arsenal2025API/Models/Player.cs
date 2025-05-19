namespace Arsenal2025API.Models;

public class Player
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Position { get; set; }

    public string Country { get; set; }

    public int? CleanSheets { get; set; }

    public int? GoalsScored { get; set; }

    public int? Assists { get; set; }
}