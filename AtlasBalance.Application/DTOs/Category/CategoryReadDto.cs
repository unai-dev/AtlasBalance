using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.Category;

public class CategoryReadDto : ReadDtoBase
{
    public string Name { get; set; } = null!;
}
