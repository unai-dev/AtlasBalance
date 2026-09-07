using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Category;

public class CategoryUpdateDto
{
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }
}
