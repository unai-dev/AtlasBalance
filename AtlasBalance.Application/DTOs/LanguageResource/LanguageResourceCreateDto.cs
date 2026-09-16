using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.LanguageResource;

public class LanguageResourceCreateDto
{
    [Required]
    public string Text { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    public int LanguageID { get; set; }
}
