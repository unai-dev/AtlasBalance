using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AtlasBalance.Application.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _http;
    private readonly AtlasDbContext _context;

    public UserService(IMapper mapper, UserManager<User> userManager, IHttpContextAccessor http, AtlasDbContext context)
    {
        _mapper = mapper;
        _userManager = userManager;
        _http = http;
        _context = context;
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

    public async Task<UserReadDto> GetCurrentUser()
    {
        if (_http.HttpContext is not null)
        {
            var claim = _http.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email")
                ?? throw new BadRequestException($"Claim with type email not found");
            return _mapper.Map<UserReadDto>(await _userManager.FindByEmailAsync(claim.Value));
        }

        throw new BadRequestException($"Error to get current user.");
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

    public async Task UpdateLanguage(int ID, int languageID)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"User with ID {ID} not found");

        var languageExists = await _context.Languages.AnyAsync(x => x.ID == languageID);
        if (!languageExists) throw new NotFoundException($"Language with ID {ID} not found");

        user.LanguageID = languageID;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) throw new BadRequestException($"Error updating language");
    }
}
