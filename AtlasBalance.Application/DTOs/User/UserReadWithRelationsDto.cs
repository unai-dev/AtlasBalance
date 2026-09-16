using AtlasBalance.Application.DTOs.Account;
using AtlasBalance.Application.DTOs.Expense;
using AtlasBalance.Application.DTOs.Language;

namespace AtlasBalance.Application.DTOs.User;

public class UserReadWithRelationsDto : UserReadDto
{
    public LanguageReadDto? Language { get; set; }
    public List<AccountReadDto> Accounts { get; set; } = new List<AccountReadDto>();

    public List<ExpenseReadDto> Expenses { get; set; } = new List<ExpenseReadDto>();
}
