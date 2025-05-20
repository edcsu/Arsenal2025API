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
        _logger.LogInformation("Searching for user with username: {Username}", username);
        var user = await _context.Users
            .FirstOrDefaultAsync(a => a.Username == username, cancellationToken);
        
        if (user is null)
            _logger.LogWarning("User not found with username: {Username}", username);
        else
            _logger.LogDebug("User found with username: {Username}", username);
            
        return user;
    }

    public async Task<User?> FindUserByEmailAsync(string email, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Searching for user with email: {Email}", email);
        var user = await _context.Users
            .FirstOrDefaultAsync(a => a.Email == email, cancellationToken);
        
        if (user is null)
            _logger.LogWarning("User not found with email: {Email}", email);
        else
            _logger.LogDebug("User found with email: {Email}", email);
            
        return user;
    }

    public async Task<User> CreateUserAsync(CreateUserRequest request, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Creating new user with username: {Username}", request.Username);
        
        var user = request.ToUser();
        user.Role = SystemRole.Admin;
        
        _context.Users.Add(user);
        try 
        {
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("Successfully created user with ID: {UserId}", user.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create user with username: {Username}", request.Username);
            throw;
        }
        return user;
    }

    public async Task<User?> FindUserByIdAsync(Guid id, 
        CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Searching for user with ID: {UserId}", id);
        var user = await _context.Users.FindAsync([id], 
            cancellationToken: cancellationToken);
            
        if (user is null)
            _logger.LogWarning("User not found with ID: {UserId}", id);
        else
            _logger.LogDebug("User found with ID: {UserId}", id);
            
        return user;
    }
}