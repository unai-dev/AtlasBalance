using AtlasBalance.Application.DTOs.Common;
using AtlasBalance.Application.DTOs.Language;

namespace AtlasBalance.Application.DTOs.LanguageResource;

public class LanguageResourceReadWithRelationsDto : LanguageResourceReadDto 
{
    public LanguageReadDto? Language { get; set; }
}
