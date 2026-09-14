using AtlasBalance.Application.DTOs.ExpensesGroup;

namespace AtlasBalance.Application.Interfaces;

public interface IExpensesGroupService
{
    Task<IEnumerable<ExpensesGroupReadDto>> GetAll(int userID);
    Task<ExpensesGroupReadDto> GetOne(int ID);
    Task<ExpensesGroupReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<ExpensesGroupReadDto> Create(ExpensesGroupCreateDto dto);
    Task Delete(int ID);
}
