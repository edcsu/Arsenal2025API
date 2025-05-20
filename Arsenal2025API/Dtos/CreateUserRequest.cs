using System.ComponentModel.DataAnnotations;
using Arsenal2025API.Models;

namespace Arsenal2025API.Dtos;

public record CreateUserRequest
{
    [Required]
    [StringLength(50)]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [MinLength(8)]
    public required string Password { get; set; }
}