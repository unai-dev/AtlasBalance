using AtlasBalance.Application.DTOs.ExpensesGroup;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Infrastructure;

using AutoMapper;

using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class ExpensesGroupService : IExpensesGroupService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public ExpensesGroupService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<IEnumerable<ExpensesGroupReadDto>> GetAll(int userID)
        => _mapper.Map<IEnumerable<ExpensesGroupReadDto>>(await _context.ExpensesGroups.Where(x => x.OwnerID == userID || x.GuestID == userID).AsNoTracking().ToListAsync());

    public async Task<ExpensesGroupReadDto> GetOne(int ID)
    {
        var group = await _context.ExpensesGroups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Group with ID {ID} not found.");

        return _mapper.Map<ExpensesGroupReadDto>(group);
    }

    public async Task<ExpensesGroupReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var group = await _context.ExpensesGroups
            .Include(x => x.Owner)
            .Include(x => x.Guest)
            .Include(x => x.Category)
            .Include(x => x.Expenses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Group with ID {ID} not found.");

        return _mapper.Map<ExpensesGroupReadWithRelationsDto>(group);
    }

    public Task<ExpensesGroupReadDto> Create(ExpensesGroupCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(int ID)
    {
        var group = await _context.ExpensesGroups.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Group with ID {ID} not found.");
        
        _context.ExpensesGroups.Remove(group);
        
        await _context.SaveChangesAsync();
    }
}
