namespace Arsenal2025API.Helpers;

public static class AuthHelpers
{
    public static readonly Guid SupervisorId = Guid.Parse("0196e9bc-e26f-7cdb-830f-dee67048db5e");
    public static readonly Guid FanId = Guid.Parse("01234567-89ab-cdef-0123-456789abcdef");
    public static readonly string ApiAdminClaim = "Admin";

    public static bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
    
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}