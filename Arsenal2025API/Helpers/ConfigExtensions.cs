namespace Arsenal2025API.Helpers;

public static class ConfigExtensions
{
    public static OtelConfing GetOtelConfing(this IConfiguration configuration)
    {
        return configuration.GetSection(OtelConfing.ConfigName).Get<OtelConfing>();
    }
    
    public static RateLimitConfig GetRateLimitConfig(this IConfiguration configuration)
    {
        return configuration.GetSection(RateLimitConfig.ConfigName).Get<RateLimitConfig>();
    }
    
    public static JwtConfig GetJwtConfig(this IConfiguration configuration)
    {
        return configuration.GetSection(JwtConfig.ConfigName).Get<JwtConfig>();
    }
}