using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserReadDto>().ReverseMap();
        CreateMap<User, UserReadWithRelationsDto>().ReverseMap();
        CreateMap<UserCreateDto, User>().ReverseMap();
    }
}
