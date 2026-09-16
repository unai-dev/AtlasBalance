using AtlasBalance.Application.DTOs.LanguageResource;
using AtlasBalance.Domain.Models;
using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class LanguageResourceProfile : Profile
{
    public LanguageResourceProfile()
    {
        CreateMap<LanguageResource, LanguageResourceReadDto>().ReverseMap();
        CreateMap<LanguageResource, LanguageResourceReadWithRelationsDto>().ReverseMap();
        CreateMap<LanguageResourceCreateDto, LanguageResource>();
        CreateMap<LanguageResourceUpdateDto, LanguageResource>();
    }
}
