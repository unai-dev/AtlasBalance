using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.Language;

public class LanguageReadDto : ReadDtoBase
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
}
