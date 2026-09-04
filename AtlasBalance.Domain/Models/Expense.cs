namespace AtlasBalance.Domain.Models;

public class Expense: BaseModel
{
    public double Amount { get; set; }
    public string Description { get; set; } = null!;

    //related properties
    public User? User { get; set; }
    public int UserID { get; set; }

    public Currency? Currency { get; set; }
    public int CurrencyID { get; set; }

    public Category? Category { get; set; }
    public int CategoryID { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }
    public int PaymentMethodID { get; set; }
}
