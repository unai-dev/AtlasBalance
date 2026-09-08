using AtlasBalance.Application.DTOs.PaymentMethod;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class PaymentMethodService : IPaymentMethodService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public PaymentMethodService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymentMethodReadDto>> GetAll()
        => _mapper.Map<IEnumerable<PaymentMethodReadDto>>(await _context.PaymentMethods.AsNoTracking().ToListAsync());

    public async Task<PaymentMethodReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var pm = await _context.PaymentMethods
            .Include(x => x.Expenses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"PaymentMethod with ID {ID} not found.");

        return _mapper.Map<PaymentMethodReadWithRelationsDto>(pm);
    }

    public async Task<PaymentMethodReadDto> GetOne(int ID)
    {
        var pm = await _context.PaymentMethods
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"PaymentMethod with ID {ID} not found.");

        return _mapper.Map<PaymentMethodReadDto>(pm);
    }

    public async Task<PaymentMethodReadDto> Create(PaymentMethodCreateDto dto)
    {
        var exists = await _context.PaymentMethods.AnyAsync(x => x.MethodType == dto.MethodType && x.ProviderName == dto.ProviderName);
        if (exists)
            throw new BadRequestException("Payment method with same type and provider already exists.");

        var pm = _mapper.Map<PaymentMethod>(dto);

        _context.PaymentMethods.Add(pm);
        await _context.SaveChangesAsync();

        return _mapper.Map<PaymentMethodReadDto>(pm);
    }

    public async Task Delete(int ID)
    {
        var pm = await _context.PaymentMethods
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"PaymentMethod with ID {ID} not found.");

        _context.PaymentMethods.Remove(pm);
        await _context.SaveChangesAsync();
    }
}
