using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.User;

public class UserReadDto : ReadDtoBase
{
    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
