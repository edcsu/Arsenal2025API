namespace Arsenal2025API.Helpers;

public class JwtConfig
{
    public const string ConfigName = "Jwt";

    public string Key { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
}