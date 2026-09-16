using AtlasBalance.Application.DTOs.LanguageResource;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class LanguageResourceService : ILanguageResourceService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public LanguageResourceService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LanguageResourceReadDto>> GetAll()
        => _mapper.Map<IEnumerable<LanguageResourceReadDto>>(await _context.LanguageResources.AsNoTracking().ToListAsync());

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

        return _mapper.Map<LanguageResourceReadDto>(resource);
    }

    public async Task Delete(int ID)
    {
        var resource = await _context.LanguageResources
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"LanguageResource with ID {ID} not found.");

        _context.LanguageResources.Remove(resource);
        await _context.SaveChangesAsync();
    }
}
