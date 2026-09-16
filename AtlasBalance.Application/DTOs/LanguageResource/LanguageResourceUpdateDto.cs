using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.LanguageResource;

public class LanguageResourceUpdateDto
{
    public string? Text { get; set; }

    public string? Description { get; set; }

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
