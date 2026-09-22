using AtlasBalance.Application.DTOs.Currency;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtlasBalance.Application.Services;

public class CurrencyService : ICurrencyService
{
    #region Fields & Dependencies
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<CurrencyService> _logger;
    #endregion

    #region Constructors
    public CurrencyService(AtlasDbContext context, IMapper mapper, ILogger<CurrencyService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    #region Public Methods
    public async Task<IEnumerable<CurrencyReadDto>> GetAll()
        => _mapper.Map<IEnumerable<CurrencyReadDto>>(await _context.Currencies.AsNoTracking().ToListAsync());

    public async Task<CurrencyReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var currency = await _context.Currencies
            .Include(x => x.Expenses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Currency with ID {ID} not found.");

        return _mapper.Map<CurrencyReadWithRelationsDto>(currency);
    }

    public async Task<CurrencyReadDto> GetOne(int ID)
    {
        var currency = await _context.Currencies
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Currency with ID {ID} not found.");

        return _mapper.Map<CurrencyReadDto>(currency);
    }

    public async Task<CurrencyReadDto> Create(CurrencyCreateDto dto)
    {
        var exists = await _context.Currencies.AnyAsync(x => x.CodeISO == dto.CodeISO || x.Name == dto.Name);
        if (exists)
            throw new BadRequestException("Currency with the same code or name already exists.");

        var currency = _mapper.Map<Currency>(dto);

        _context.Currencies.Add(currency);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created Currency with ID {Id} code {Code}", currency.ID, currency.CodeISO);

        return _mapper.Map<CurrencyReadDto>(currency);
    }

    public async Task Delete(int ID)
    {
        var currency = await _context.Currencies
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Currency with ID {ID} not found.");

        _context.Currencies.Remove(currency);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Deleted Currency with ID {Id}", ID);
    }
    #endregion

    #region Private Methods & Helpers

    #endregion
}
