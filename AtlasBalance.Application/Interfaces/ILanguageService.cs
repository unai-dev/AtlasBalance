using AtlasBalance.Application.DTOs.Language;

namespace AtlasBalance.Application.Interfaces;

public interface ILanguageService
{
    Task<IEnumerable<LanguageReadDto>> GetAll();
    Task<LanguageReadDto> GetOne(int ID);
    Task<LanguageReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<LanguageReadDto> Create(LanguageCreateDto dto);
    Task Delete(int ID);
}
