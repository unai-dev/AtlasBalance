using AtlasBalance.Application.DTOs.User;

namespace AtlasBalance.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserReadDto>> GetAll();
    Task<UserReadDto> GetOne(int ID);
    Task<UserReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<UserReadDto> Create(UserCreateDto dto);
    Task Delete(int ID);
}
