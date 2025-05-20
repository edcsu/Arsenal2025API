using Arsenal2025API.Data;
using Arsenal2025API.Dtos;
using Arsenal2025API.Mappers;
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

    public async Task<User?> FindUserByUsernameAsync(string username, 
        CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(a => a.Username == username, cancellationToken);
        
        return user;
    }

    public async Task<User?> FindUserByEmailAsync(string email, 
        CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
        
        return user;
    }

    public async Task<User> CreateUserAsync(CreateUserRequest request, 
        CancellationToken cancellationToken = default)
    {
        var user = request.ToUser();
        user.Role = SystemRole.Admin;
        
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User?> FindUserByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var user = await _context.Users.FindAsync([id], 
            cancellationToken: cancellationToken);
        return user;
    }
}