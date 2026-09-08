using AtlasBalance.Application.DTOs.PaymentMethod;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class PaymentMethodProfile : Profile
{
    public PaymentMethodProfile()
    {
        CreateMap<PaymentMethod, PaymentMethodReadDto>().ReverseMap();
        CreateMap<PaymentMethod, PaymentMethodReadWithRelationsDto>().ReverseMap();
        CreateMap<PaymentMethodCreateDto, PaymentMethod>().ReverseMap();
        CreateMap<PaymentMethodUpdateDto, PaymentMethod>().ReverseMap();
    }
}
