using AtlasBalance.Application.DTOs.Expense;

namespace AtlasBalance.Application.Interfaces;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseReadDto>> GetAll();
    Task<ExpenseReadDto> GetOne(int ID);
    Task<ExpenseReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<ExpenseReadDto> Create(ExpenseCreateDto dto);
    Task Delete(int ID);
}
