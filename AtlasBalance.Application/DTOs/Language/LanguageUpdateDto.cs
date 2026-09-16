using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Language;

public class LanguageUpdateDto
{
    [StringLength(55)]
    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
