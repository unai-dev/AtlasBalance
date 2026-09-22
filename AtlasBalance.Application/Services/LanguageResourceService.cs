using AtlasBalance.Application.DTOs.LanguageResource;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtlasBalance.Application.Services;

public class LanguageResourceService : ILanguageResourceService
{
    #region Fields & Dependencies
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly ILogger<LanguageResourceService> _logger;
    #endregion

    #region Constructors
    public LanguageResourceService(AtlasDbContext context, IMapper mapper, IUserService userService, ILogger<LanguageResourceService> logger)
    {
        _context = context;
        _mapper = mapper;
        _userService = userService;
        _logger = logger;
    }
    #endregion

    #region Public Methods
    public async Task<IEnumerable<LanguageResourceReadDto>> GetAll()
        => _mapper.Map<IEnumerable<LanguageResourceReadDto>>(await _context.LanguageResources.AsNoTracking().ToListAsync());

    public async Task<IEnumerable<LanguageResourceReadDto>> GetAllWithLanguageID()
    {
        var user = await _userService.GetCurrentUser();
        var languageID = user.LanguageID;
        
        return _mapper.Map<IEnumerable<LanguageResourceReadDto>>(await _context.LanguageResources
            .Where(x => x.LanguageID == languageID)
            .AsNoTracking()
            .ToListAsync());
    }

    public async Task<LanguageResourceReadDto> GetOne(int ID)
    {
        var resource = await _context.LanguageResources
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"LanguageResource with ID {ID} not found.");

        return _mapper.Map<LanguageResourceReadDto>(resource);
    }

    public async Task<LanguageResourceReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var resource = await _context.LanguageResources
            .Include(x => x.Language)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"LanguageResource with ID {ID} not found.");

        return _mapper.Map<LanguageResourceReadWithRelationsDto>(resource);
    }

    public async Task<LanguageResourceReadDto> Create(LanguageResourceCreateDto dto)
    {
        var languageExists = await _context.Languages.AnyAsync(x => x.ID == dto.LanguageID);
        if (!languageExists)
            throw new BadRequestException($"Language with ID {dto.LanguageID} does not exist.");

        var textExists = await _context.LanguageResources.AnyAsync(x => x.Text == dto.Text);
        if (textExists)
            throw new BadRequestException($"LanguageResource with text '{dto.Text}' already exists.");

        var resource = _mapper.Map<LanguageResource>(dto);
        _context.LanguageResources.Add(resource);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created LanguageResource with ID {Id} text {Text}", resource.ID, resource.Text);

        return _mapper.Map<LanguageResourceReadDto>(resource);
    }

    public async Task Delete(int ID)
    {
        var resource = await _context.LanguageResources
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"LanguageResource with ID {ID} not found.");

        _context.LanguageResources.Remove(resource);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Deleted LanguageResource with ID {Id}", ID);
    }
    #endregion

    #region Private Methods & Helpers

    #endregion
}
