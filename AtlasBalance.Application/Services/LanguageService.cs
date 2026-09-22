using AtlasBalance.Application.DTOs.Language;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtlasBalance.Application.Services;

public class LanguageService : ILanguageService
{
    #region Fields & Dependencies
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogger<LanguageService> _logger;
    #endregion

    #region Constructors
    public LanguageService(AtlasDbContext context, IMapper mapper, ILogger<LanguageService> logger)
    {
        _context = context;
        _mapper = mapper;
        _logger = logger;
    }
    #endregion

    #region Public Methods
    public async Task<IEnumerable<LanguageReadDto>> GetAll()
        => _mapper.Map<IEnumerable<LanguageReadDto>>(await _context.Languages.AsNoTracking().ToListAsync());

    public async Task<LanguageReadDto> GetOne(int ID)
    {
        var language = await _context.Languages
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Language with ID {ID} not found.");

        return _mapper.Map<LanguageReadDto>(language);
    }

    public async Task<LanguageReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var language = await _context.Languages
            .Include(x => x.Users)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Language with ID {ID} not found.");

        return _mapper.Map<LanguageReadWithRelationsDto>(language);
    }

    public async Task<LanguageReadDto> Create(LanguageCreateDto dto)
    {
        var exists = await _context.Languages.AnyAsync(x => x.Code == dto.Code);

        if (exists)
            throw new BadRequestException($"Language with code '{dto.Code}' already exists.");

        var language = _mapper.Map<Language>(dto);
        _context.Languages.Add(language);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created Language with ID {Id} code {Code}", language.ID, language.Code);

        return _mapper.Map<LanguageReadDto>(language);
    }

    public async Task Delete(int ID)
    {
        var language = await _context.Languages
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Language with ID {ID} not found.");

        _context.Languages.Remove(language);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Deleted Language with ID {Id}", ID);
    }
    #endregion

    #region Private Methods & Helpers

    #endregion
}
