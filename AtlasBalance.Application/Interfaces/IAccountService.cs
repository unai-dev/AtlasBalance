using AtlasBalance.Application.DTOs.Account;

namespace AtlasBalance.Application.Interfaces;

public interface IAccountService
{
    Task<IEnumerable<AccountReadDto>> GetAll();
    Task<AccountReadDto> GetOne(int ID);
    Task<AccountReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<AccountReadDto> Create(AccountCreateDto dto);
    Task Delete(int ID);
}
