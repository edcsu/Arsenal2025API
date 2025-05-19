using System.Text.Json;
using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public class DataService
{
    public DataService(IWebHostEnvironment webHostEnvironment) 
    {
        WebHostEnvironment = webHostEnvironment;
    }

    private IWebHostEnvironment WebHostEnvironment { get; }
    
    private string PlayersFileName => Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "players.json");
    private string CoachesFileName => Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "coaches.json");

    private readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };
    
    public IEnumerable<Player> GetPlayers()
    {
        using StreamReader streamReader = new(PlayersFileName);
        var json = streamReader.ReadToEnd();
        return JsonSerializer.Deserialize<IEnumerable<Player>>(json, Options) ?? [];
    }
    
    public IEnumerable<Player> GetCoaches()
    {
        using StreamReader streamReader = new(CoachesFileName);
        var json = streamReader.ReadToEnd();
        return JsonSerializer.Deserialize<IEnumerable<Player>>(json, Options) ?? [];
    }
}