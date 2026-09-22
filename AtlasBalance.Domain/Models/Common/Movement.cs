namespace AtlasBalance.Domain.Models.Common;

public abstract class Movement : BaseModel
{
    #region Properties
    public double Amount { get; set; }
    public string Description { get; set; } = null!;
    public DateTime MovementDate { get; set; }
    #endregion

    #region Related Properties
    public int UserID { get; set; }
    public User? User { get; set; }

    public int CurrencyID { get; set; }
    public Currency? Currency { get; set; }

    public int CategoryID { get; set; }
    public Category? Category { get; set; }

    public int PaymentMethodID { get; set; }
    public PaymentMethod? PaymentMethod { get; set; }

    public int AccountID { get; set; }
    public Account? Account { get; set; }
    #endregion
}
