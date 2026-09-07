using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Category;

public class CategoryCreateDto
{
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;
}
