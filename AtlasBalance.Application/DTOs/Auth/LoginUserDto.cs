using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Auth;

public class LoginUserDto
{
    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}
