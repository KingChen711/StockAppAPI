using System.ComponentModel.DataAnnotations;

namespace StockAPI.DTO.User;

public record LoginDto
{
    [Required(ErrorMessage = "Username/Email is required.")]
    public required string UsernameOrEmail { get; init; }

    [Required(ErrorMessage = "Password is required.")]
    public required string Password { get; init; }
}
