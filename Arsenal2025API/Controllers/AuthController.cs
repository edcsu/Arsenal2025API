using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Text;
using Arsenal2025API.Dtos;
using Arsenal2025API.Helpers;
using Arsenal2025API.Mappers;
using Arsenal2025API.Models;
using Arsenal2025API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;

namespace Arsenal2025API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class AuthController: ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, 
        ILogger<AuthController> logger, 
        IConfiguration configuration)
    {
        _authService = authService;
        _logger = logger;
        _configuration = configuration;
    }

    [HttpPost("login")]
    [Stability(Stability.Stable)]
    [ProducesResponseType(typeof(LoginResponse),StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Generates an access token")]
    [EndpointDescription("Get an access token to use the API")]
    public async Task<ActionResult<LoginResponse>> Login([FromBody]LoginRequest request, 
        CancellationToken cancellationToken = default)
    {
        var user = await _authService.FindUserByUsernameAsync(request.Username, cancellationToken);

        if (user is null || 
            !AuthHelpers.VerifyPassword(request.Password, user.PasswordHash))
        {
            _logger.LogError("Invalid username or password for {Username}", request.Username);
            return Unauthorized();
        }
        
        // Check if the admin is active
        if (!user.IsActive)
        {
            _logger.LogError("User {Username} is not active", request.Username);
            return Unauthorized("This account has been disabled. Please contact your system administrator.");
        }

        var loginResponse = GenerateJwtToken(user);
        _logger.LogInformation("Generated token for user {Username}", request.Username);
        return Ok(loginResponse);
    }
    
    [HttpPost("admins")]
    [Authorize(Roles = "Admin, Supervisor")]
    [Stability(Stability.Stable)]
    [ProducesResponseType(typeof(UserResponse),StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Create an admin")]
    [EndpointDescription("Create an admin for the API")]
    public async Task<ActionResult<UserResponse>> CreateAdmin(CreateUserRequest request,
        CancellationToken cancellationToken = default)
    {
        // Check if a username already exists
        var saccoAdminWithUsername = await _authService.FindUserByUsernameAsync(request.Username, cancellationToken);
        if (saccoAdminWithUsername is not null)
        {
            _logger.LogError("User {Username} already exists", request.Username);
            return BadRequest("Username already exists");
        }

        // Check if email already exists
        var saccoAdminWithEmail = await _authService.FindUserByEmailAsync(request.Email, cancellationToken);
        if (saccoAdminWithEmail is not null)
        {
            _logger.LogError("Email for {Username} already exists", request.Username);
            return BadRequest("Email already exists");
        }

        var user = await _authService.CreateUserAsync(request, cancellationToken);

        var response = user.ToUserResponse();

        return CreatedAtAction(nameof(GetUser), new { id = response.Id }, response);
    }
    
    [HttpGet("admins/{id:guid}")]
    [Authorize(Roles = "Admin, Supervisor")]
    [Stability(Stability.Stable)]
    [ProducesResponseType(typeof(UserResponse),StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType( StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [EndpointSummary("Get a user")]
    [EndpointDescription("Get details for a user")]
    public async Task<ActionResult<UserResponse>> GetUser(Guid id, 
        CancellationToken cancellationToken = default)
    {
        var user = await _authService.FindUserByIdAsync(id, cancellationToken);

        if (user is null)
        {
            _logger.LogError("User with id: {Id} does not exists", id);
            return NotFound();
        }

        
        var response = user.ToUserResponse();
        _logger.LogError("User with Id: {Id} exists", id);

        return Ok(response);
    }
    
    private LoginResponse GenerateJwtToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role == SystemRole.Admin ? "Admin" : "Supervisor"),
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials);

        return new LoginResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresIn = 3600,
        };
    }
}