using System.Text.Json;
using Arsenal2025API.Models;

namespace Arsenal2025API.Services;

public class DataService
{
    private readonly ILogger<DataService> _logger;
    public DataService(IWebHostEnvironment webHostEnvironment, 
        ILogger<DataService> logger)
    {
        WebHostEnvironment = webHostEnvironment;
        _logger = logger;
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
        _logger.LogInformation("Getting players");
        using StreamReader streamReader = new(PlayersFileName);
        var json = streamReader.ReadToEnd();
        _logger.LogInformation("Finished getting players");
        return JsonSerializer.Deserialize<IEnumerable<Player>>(json, Options) ?? [];
    }
    
    public IEnumerable<Player> GetCoaches()
    {
        _logger.LogInformation("Getting coaches");
        using StreamReader streamReader = new(CoachesFileName);
        var json = streamReader.ReadToEnd();
        _logger.LogInformation("Finished getting coaches");
        return JsonSerializer.Deserialize<IEnumerable<Player>>(json, Options) ?? [];
    }
}