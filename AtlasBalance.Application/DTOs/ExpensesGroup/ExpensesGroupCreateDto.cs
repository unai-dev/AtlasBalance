using System.ComponentModel.DataAnnotations;

namespace AtlasBalance.Application.DTOs.ExpensesGroup;

public class ExpensesGroupCreateDto
{
    [Required]
    [StringLength(55)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(2000)]
    public string Description { get; set; } = null!;

    [Required]
    public int OwnerID { get; set; }

    [Required]
    public int GuestID { get; set; }

    [Required]
    public int CategoryID { get; set; }
}
