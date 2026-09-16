using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Language;

public class LanguageUpdateDto
{
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
