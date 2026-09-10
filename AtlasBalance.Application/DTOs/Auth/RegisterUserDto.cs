using System.ComponentModel.DataAnnotations;

using AtlasBalance.Application.DTOs.User;

namespace AtlasBalance.Application.DTOs.Auth;

public class RegisterUserDto: UserCreateDto
{
    [Required]
    public string Password { get; set; } = null!;
}
