using AtlasBalance.Application.DTOs.Common;
using AtlasBalance.Application.DTOs.User;

namespace AtlasBalance.Application.DTOs.Language;

public class LanguageReadWithRelationsDto : LanguageReadDto
{
    public List<UserReadDto> Users { get; set; } = new List<UserReadDto>();
}
