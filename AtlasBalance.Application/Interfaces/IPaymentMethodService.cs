using AtlasBalance.Application.DTOs.PaymentMethod;

namespace AtlasBalance.Application.Interfaces;

public interface IPaymentMethodService
{
    Task<IEnumerable<PaymentMethodReadDto>> GetAll();
    Task<PaymentMethodReadDto> GetOne(int ID);
    Task<PaymentMethodReadWithRelationsDto> GetOneWithRelations(int ID);
    Task<PaymentMethodReadDto> Create(PaymentMethodCreateDto dto);
    Task Delete(int ID);
}
