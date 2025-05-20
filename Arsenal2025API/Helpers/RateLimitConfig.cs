namespace Arsenal2025API.Helpers;

public class RateLimitConfig
{
    public const string ConfigName = "RateLimit";

    public int PermitLimit { get; set; } = 1;

    public int Window { get; set; } = 5;
        
    public int QueueLimit { get; set; } = 2;

    public List<string> AllowedPaths { get; set; } = [];
}