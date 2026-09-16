using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.LanguageResource;

public class LanguageResourceReadDto : ReadDtoBase
{
    public string Text { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int LanguageID { get; set; }
}
