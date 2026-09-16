using System;
using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.ExpensesGroup;

public class ExpensesGroupUpdateDto
{
    [StringLength(55)]
    public string? Name { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    public int? OwnerID { get; set; }

    public int? GuestID { get; set; }

    public int? CategoryID { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
