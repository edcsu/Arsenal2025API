namespace Arsenal2025API.Helpers;

public static class ConfigExtensions
{
    public static OtelConfing GetOtelConfing(this IConfiguration configuration)
    {
        return configuration.GetSection(OtelConfing.ConfigName).Get<OtelConfing>();
    }
    
    public static RateLimitConfig GetConfigName(this IConfiguration configuration)
    {
        return configuration.GetSection(RateLimitConfig.ConfigName).Get<RateLimitConfig>();
    }
}