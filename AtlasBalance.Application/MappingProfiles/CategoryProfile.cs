using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Application.DTOs.Category;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class CategoryProfile: Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryReadDto>().ReverseMap();
        CreateMap<Category, CategoryReadWithRelationsDto>().ReverseMap();
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
    }
}
