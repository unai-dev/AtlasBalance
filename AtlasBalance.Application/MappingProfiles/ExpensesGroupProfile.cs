using AtlasBalance.Application.DTOs.ExpensesGroup;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class ExpensesGroupProfile : Profile
{
    public ExpensesGroupProfile()
    {
        CreateMap<ExpensesGroup, ExpensesGroupReadDto>().ReverseMap();
        CreateMap<ExpensesGroup, ExpensesGroupReadWithRelationsDto>().ReverseMap();
        CreateMap<ExpensesGroupCreateDto, ExpensesGroup>().ReverseMap();
        CreateMap<ExpensesGroupUpdateDto, ExpensesGroup>().ReverseMap();
    }
}
