using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.User;

public class UserCreateDto
{
    [Required]
    [StringLength(256)]
    public string UserName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = null!;
}
