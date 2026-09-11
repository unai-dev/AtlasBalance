using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;

    public UserService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserReadDto>> GetAll()
        => _mapper.Map<IEnumerable<UserReadDto>>(await _userManager.Users.AsNoTracking().ToListAsync());

    public async Task<UserReadWithRelationsDto> GetOneWithRelations(int ID)
    {
        var user = await _userManager.Users
            .Include(x => x.Accounts)
            .Include(x => x.Expenses)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == ID)
            ?? throw new NotFoundException($"User with ID {ID} not found.");

        return _mapper.Map<UserReadWithRelationsDto>(user);
    }

    public async Task<UserReadDto> GetOne(int ID)
    {
        var user = await _userManager.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == ID)
            ?? throw new NotFoundException($"User with ID {ID} not found.");

        return _mapper.Map<UserReadDto>(user);
    }

    public async Task<UserReadDto> Create(UserCreateDto dto)
    {
        var existing = await _userManager.FindByEmailAsync(dto.Email);

        if (existing != null)
            throw new BadRequestException("User with the same email already exists.");


        var user = new User
        {
            // generate username from email before @
            UserName = dto.Email.Split('@')[0],
            Email = dto.Email
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
            throw new BadRequestException("Failed to create user");

        return _mapper.Map<UserReadDto>(user);
    }

    public async Task Delete(int ID)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"User with ID {ID} not found.");

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
            throw new BadRequestException("Failed to delete user");
    }
}
