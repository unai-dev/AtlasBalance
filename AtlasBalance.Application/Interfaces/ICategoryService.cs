using AtlasBalance.Application.DTOs.Category;

namespace AtlasBalance.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryReadDto> Create(CategoryCreateDto dto);
        Task Delete(int ID);
        Task<IEnumerable<CategoryReadDto>> GetAll();
        Task<CategoryReadDto> GetOne(int ID);
        Task<CategoryReadWithRelationsDto> GetOneWithRelations(int ID);
    }
}