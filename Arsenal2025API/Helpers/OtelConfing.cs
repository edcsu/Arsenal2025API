namespace Arsenal2025API.Helpers;

public class OtelConfing
{
    public const string ConfigName = "OtelConfing";

    public string Endpoint { get; init; } = null!;

    public bool Enabled { get; init; } = false;
}