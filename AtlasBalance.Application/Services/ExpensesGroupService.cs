using AtlasBalance.Application.DTOs.ExpensesGroup;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class ExpensesGroupService : IExpensesGroupService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly ILogger<ExpensesGroupService> _logger;

    public ExpensesGroupService(AtlasDbContext context, IMapper mapper, UserManager<User> userManager, IUserService userService, ILogger<ExpensesGroupService> logger)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _userService = userService;
        _logger = logger;
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

    public async Task<ExpensesGroupReadDto> Create(ExpensesGroupCreateDto dto)
    {
        var categoryExists = await _context.Categories.AnyAsync(x => x.ID == dto.CategoryID);
        if (!categoryExists) throw new NotFoundException($"Category with ID {dto.CategoryID} not found.");

        var guestExists = await _userManager.Users.AnyAsync(x => x.Id ==  dto.GuestID);
        if (!guestExists) throw new NotFoundException($"Guest with ID {dto.GuestID} not found.");

        var owner = await _userService.GetCurrentUser();

        var group = _mapper.Map<ExpensesGroup>(dto);

        group.OwnerID = owner.ID;
        _context.ExpensesGroups.Add(group);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Created ExpensesGroup with ID {Id} owner {OwnerId}", group.ID, group.OwnerID);

        return _mapper.Map<ExpensesGroupReadDto>(group);
    }

    public async Task Delete(int ID)
    {
        var group = await _context.ExpensesGroups.FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Group with ID {ID} not found.");

        _context.ExpensesGroups.Remove(group);

        await _context.SaveChangesAsync();

        _logger.LogInformation("Deleted ExpensesGroup with ID {Id}", ID);
    }
}
