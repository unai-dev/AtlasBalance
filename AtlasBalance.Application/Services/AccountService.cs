using AtlasBalance.Application.DTOs.Account;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class AccountService : IAccountService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public AccountService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AccountReadDto>> GetAll()
        => _mapper.Map<IEnumerable<AccountReadDto>>(await _context.Accounts.AsNoTracking().ToListAsync());

    public async Task<AccountReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var account = await _context.Accounts
            .Include(x => x.User)
            .Include(x => x.Expenses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Account with ID {ID} not found.");

        return _mapper.Map<AccountReadWithRelationsDto>(account);
    }

    public async Task<AccountReadDto> GetOne(int ID)
    {
        var account = await _context.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Account with ID {ID} not found.");

        return _mapper.Map<AccountReadDto>(account);
    }

    public async Task<AccountReadDto> Create(AccountCreateDto dto)
    {
        if (dto.Amount < 0)
            throw new BadRequestException("Amount cannot be negative.");

        var duplicate = await _context.Accounts.AnyAsync(x => x.IBAN == dto.IBAN);
        if (duplicate)
            throw new BadRequestException("Account with the same IBAN already exists.");

        var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserID);
        if (!userExists)
            throw new NotFoundException($"User with ID {dto.UserID} not found.");

        var account = _mapper.Map<Account>(dto);

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return _mapper.Map<AccountReadDto>(account);
    }

    public async Task Delete(int ID)
    {
        var account = await _context.Accounts
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Account with ID {ID} not found.");

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }
}
