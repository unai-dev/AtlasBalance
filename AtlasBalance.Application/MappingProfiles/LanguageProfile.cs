using AtlasBalance.Application.DTOs.Language;
using AtlasBalance.Domain.Models;
using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<Language, LanguageReadDto>().ReverseMap();
        CreateMap<Language, LanguageReadWithRelationsDto>().ReverseMap();
        CreateMap<LanguageCreateDto, Language>();
        CreateMap<LanguageUpdateDto, Language>();
    }
}
