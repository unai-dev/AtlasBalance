using AtlasBalance.Application.DTOs.Expense;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly AtlasDbContext _context;
    private readonly IMapper _mapper;

    public ExpenseService(AtlasDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ExpenseReadDto>> GetAll()
        => _mapper.Map<IEnumerable<ExpenseReadDto>>(await _context.Expenses.AsNoTracking().ToListAsync());

    public async Task<ExpenseReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var expense = await _context.Expenses
            .Include(x => x.User)
            .Include(x => x.Currency)
            .Include(x => x.Category)
            .Include(x => x.PaymentMethod)
            .Include(x => x.Account)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Expense with ID {ID} not found.");

        return _mapper.Map<ExpenseReadWithRelationsDto>(expense);
    }

    public async Task<ExpenseReadDto> GetOne(int ID)
    {
        var expense = await _context.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Expense with ID {ID} not found.");

        return _mapper.Map<ExpenseReadDto>(expense);
    }

    public async Task<ExpenseReadDto> Create(ExpenseCreateDto dto)
    {
        if (dto.Amount <= 0)
            throw new BadRequestException("Amount must be greater than zero.");

        // validate foreign keys existence (only existence checks)
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

        var expense = _mapper.Map<Expense>(dto);

        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();

        return _mapper.Map<ExpenseReadDto>(expense);
    }

    public async Task Delete(int ID)
    {
        var expense = await _context.Expenses
            .FirstOrDefaultAsync(x => x.ID == ID)
            ?? throw new NotFoundException($"Expense with ID {ID} not found.");

        _context.Expenses.Remove(expense);
        await _context.SaveChangesAsync();
    }
}
