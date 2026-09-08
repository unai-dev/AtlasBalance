using AtlasBalance.Application.DTOs.Currency;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class CurrencyProfile : Profile
{
    public CurrencyProfile()
    {
        CreateMap<Currency, CurrencyReadDto>().ReverseMap();
        CreateMap<Currency, CurrencyReadWithRelationsDto>().ReverseMap();
        CreateMap<CurrencyCreateDto, Currency>().ReverseMap();
        CreateMap<CurrencyUpdateDto, Currency>().ReverseMap();
    }
}
