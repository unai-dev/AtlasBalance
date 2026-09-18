using AtlasBalance.Application.DTOs.Transfer;

namespace AtlasBalance.Application.Interfaces;

public interface ITransferService
{
    Task<IEnumerable<TransferReadDto>> GetAll();
    Task<TransferReadDto> GetOne(int ID);
    Task<TransferReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<TransferReadDto> Create(TransferCreateDto dto);
    Task Delete(int ID);
}
