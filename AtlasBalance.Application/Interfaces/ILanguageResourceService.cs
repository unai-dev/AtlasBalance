using AtlasBalance.Application.DTOs.LanguageResource;

namespace AtlasBalance.Application.Interfaces;

public interface ILanguageResourceService
{
    Task<IEnumerable<LanguageResourceReadDto>> GetAll();
    Task<LanguageResourceReadDto> GetOne(int ID);
    Task<LanguageResourceReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<LanguageResourceReadDto> Create(LanguageResourceCreateDto dto);
    Task Delete(int ID);
}
