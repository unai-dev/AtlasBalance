using AtlasBalance.Application.DTOs.Currency;

namespace AtlasBalance.Application.Interfaces;

public interface ICurrencyService
{
    Task<IEnumerable<CurrencyReadDto>> GetAll();
    Task<CurrencyReadDto> GetOne(int ID);
    Task<CurrencyReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<CurrencyReadDto> Create(CurrencyCreateDto dto);
    Task Delete(int ID);
}
