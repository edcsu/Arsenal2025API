namespace Arsenal2025API.Models;

public class Coach
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public int TotalTrophies { get; set; }

    public string Tenure { get; set; }
}