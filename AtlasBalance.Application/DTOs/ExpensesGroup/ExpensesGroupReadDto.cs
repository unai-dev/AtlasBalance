using System;
using AtlasBalance.Application.DTOs.Common;

namespace AtlasBalance.Application.DTOs.ExpensesGroup;

public class ExpensesGroupReadDto : ReadDtoBase
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int OwnerID { get; set; }

    public int GuestID { get; set; }

    public int CategoryID { get; set; }
}
