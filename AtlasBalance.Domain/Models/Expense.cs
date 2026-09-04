namespace AtlasBalance.Domain.Models;

public class Expense: BaseModel
{
    public double Amount { get; set; }
    public string Description { get; set; } = null!;

    //related properties
    public User? User { get; set; }
    public int UserID { get; set; }
}
