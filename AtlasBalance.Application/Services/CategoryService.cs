using System;
using System.Collections.Generic;
using System.Text;

using AtlasBalance.Application.DTOs.Category;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public CategoryService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryReadDto>> GetAll()
        => _mapper.Map<IEnumerable<CategoryReadDto>>(
            await _context.Categories
            .AsNoTracking()
            .ToListAsync());

    public async Task<CategoryReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var category = await _context.Categories
            .Include(x => x.Expenses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Category with ID {ID} not found.");

        return _mapper.Map<CategoryReadWithRelationsDto>(category);
    }

    public async Task<CategoryReadDto> GetOne(int ID)
    {
        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Category with ID {ID} not found.");

        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task<CategoryReadDto> Create(CategoryCreateDto dto)
    {
        var existingCategory = await _context.Categories.AnyAsync(x => x.Name == dto.Name);

        if (existingCategory)
            throw new BadRequestException("Category with the same name already exists.");

        var category = _mapper.Map<Category>(dto);

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();

        return _mapper.Map<CategoryReadDto>(category);
    }

    public async Task Delete(int ID)
    {
        var category = await _context.Categories
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Category with ID {ID} not found.");

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

}
