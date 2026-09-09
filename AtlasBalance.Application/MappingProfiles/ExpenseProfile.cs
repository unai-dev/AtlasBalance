using AtlasBalance.Application.DTOs.Expense;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<Expense, ExpenseReadDto>().ReverseMap();
        CreateMap<Expense, ExpenseReadWithRelationsDto>().ReverseMap();
        CreateMap<ExpenseCreateDto, Expense>().ReverseMap();
        CreateMap<ExpenseUpdateDto, Expense>().ReverseMap();
    }
}
