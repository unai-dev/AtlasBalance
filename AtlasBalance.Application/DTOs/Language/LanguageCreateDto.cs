using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Language;

public class LanguageCreateDto
{
    [Required]
    [StringLength(2)]
    public string Code { get; set; } = null!;

    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;
}
