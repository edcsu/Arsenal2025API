using Arsenal2025API.Data;
using Arsenal2025API.Models;
using Microsoft.EntityFrameworkCore;

namespace Arsenal2025API.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AuthService> _logger;

    public AuthService(ApplicationDbContext context, 
        ILogger<AuthService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<User?> FindUserByUsername(string username, 
        CancellationToken cancellationToken = default)
    {
        var admin = await _context.Users
            .FirstOrDefaultAsync(a => a.Username == username, cancellationToken);
        
        return admin;
    }
}