using AtlasBalance.Application.DTOs.Transfer;
using AtlasBalance.Domain.Models;

using AutoMapper;

namespace AtlasBalance.Application.MappingProfiles;

public class TransferProfile : Profile
{
    public TransferProfile()
    {
        CreateMap<Transfer, TransferReadDto>().ReverseMap();
        CreateMap<Transfer, TransferReadWithRelationsDto>().ReverseMap();
        CreateMap<TransferCreateDto, Transfer>().ReverseMap();
        CreateMap<TransferUpdateDto, Transfer>().ReverseMap();
    }
}
