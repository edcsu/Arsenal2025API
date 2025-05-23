namespace Arsenal2025API.Helpers;

public static class AuthHelpers
{
    public static readonly Guid SupervisorId = Guid.Parse("0196e9bc-e26f-7cdb-830f-dee67048db5e");
    public static readonly Guid FanId = Guid.Parse("01234567-89ab-cdef-0123-456789abcdef");
    public const string ApiAdminClaim = "Admin";
    public const string ApiSupervisorClaim = "Supervisor";
    public const string ApplicationName = "Demo API";
    public const int TokenExpirationHours = 1;
    public const int TokenExpirationSeconds = 3600;
    
    public static bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
    
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}