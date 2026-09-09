using AtlasBalance.Application.DTOs.Account;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountReadDto>().ReverseMap();
        CreateMap<Account, AccountReadWithRelationsDto>().ReverseMap();
        CreateMap<AccountCreateDto, Account>().ReverseMap();
        CreateMap<AccountUpdateDto, Account>().ReverseMap();
    }
}
