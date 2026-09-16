using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.LanguageResource;

public class LanguageResourceUpdateDto
{
    [Required]
    public string Text { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
