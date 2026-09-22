using AtlasBalance.Application.DTOs.Transfer;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtlasBalance.Application.Services;

/// <summary>
/// Servicio para operaciones sobre Transfer.
/// - Valida existencia de entidades relacionadas antes de persistir.
/// - Usa consultas optimizadas (AsNoTracking) y mapeo AutoMapper.
/// </summary>
public class TransferService : ITransferService
{
    #region Fields & Dependencies
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<TransferService> _logger;
    #endregion

    #region Constructors
    public TransferService(AtlasDbContext context, IMapper mapper, ILogger<TransferService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    #region Public Methods
    public async Task<IEnumerable<TransferReadDto>> GetAll()
    {
        var transfers = await _context.Transfers
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<TransferReadDto>>(transfers);
    }

    public async Task<TransferReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var transfer = await _context.Transfers
            .Include(t => t.User)
            .Include(t => t.Currency)
            .Include(t => t.Category)
            .Include(t => t.PaymentMethod)
            .Include(t => t.Account)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.ID == ID)
            ?? throw new NotFoundException($"Transfer with ID {ID} not found.");

        return _mapper.Map<TransferReadWithRelationsDto>(transfer);
    }

    public async Task<TransferReadDto> GetOne(int ID)
    {
        var transfer = await _context.Transfers
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.ID == ID)
            ?? throw new NotFoundException($"Transfer with ID {ID} not found.");

        return _mapper.Map<TransferReadDto>(transfer);
    }

    public async Task<TransferReadDto> Create(TransferCreateDto dto)
    {
        // Declarative existence checks for related entities
        var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserID);
        if (!userExists) throw new NotFoundException($"User with ID {dto.UserID} not found.");

        var currencyExists = await _context.Currencies.AnyAsync(c => c.ID == dto.CurrencyID);
        if (!currencyExists) throw new NotFoundException($"Currency with ID {dto.CurrencyID} not found.");

        var categoryExists = await _context.Categories.AnyAsync(c => c.ID == dto.CategoryID);
        if (!categoryExists) throw new NotFoundException($"Category with ID {dto.CategoryID} not found.");

        var paymentMethodExists = await _context.PaymentMethods.AnyAsync(p => p.ID == dto.PaymentMethodID);
        if (!paymentMethodExists) throw new NotFoundException($"PaymentMethod with ID {dto.PaymentMethodID} not found.");

        var accountExists = await _context.Accounts.AnyAsync(a => a.ID == dto.AccountID);
        if (!accountExists) throw new NotFoundException($"Account with ID {dto.AccountID} not found.");

        var transfer = _mapper.Map<Transfer>(dto);

        _context.Transfers.Add(transfer);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created Transfer with ID {Id} from {Sender} to {Addressee} amount {Amount}", transfer.ID, transfer.Sender, transfer.Addressee, transfer.Amount);

        return _mapper.Map<TransferReadDto>(transfer);
    }

    public async Task Delete(int ID)
    {
        var transfer = await _context.Transfers.FirstOrDefaultAsync(t => t.ID == ID)
            ?? throw new NotFoundException($"Transfer with ID {ID} not found.");

        _context.Transfers.Remove(transfer);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Deleted Transfer with ID {Id}", ID);
    }
    #endregion

    #region Private Methods & Helpers

    #endregion
}
