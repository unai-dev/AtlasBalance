using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.Category;

public class CategoryUpdateDto
{
    [StringLength(55)]
    public string? Name { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
