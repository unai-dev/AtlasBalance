using Microsoft.AspNetCore.Identity;

namespace AtlasBalance.Domain.Models;

public class User: IdentityUser<int>
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
