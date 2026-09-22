using AtlasBalance.Application.DTOs.User;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Domain.Exceptions;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using AutoMapper;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AtlasBalance.Application.Services;

public class UserService : IUserService
{
    #region Fields & Dependencies
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _http;
    private readonly AtlasDbContext _context;
    private readonly ILogger<UserService> _logger;
    #endregion

    #region Constructors
    public UserService(IMapper mapper, UserManager<User> userManager, IHttpContextAccessor http, AtlasDbContext context, ILogger<UserService> logger)
    {
        _mapper = mapper;
        _userManager = userManager;
        _http = http;
        _context = context;
        _logger = logger;
    }
    #endregion

    #region Public Methods
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
        {
            _logger.LogError("Failed to create user {Email}: {Errors}", dto.Email, result.Errors);
            throw new BadRequestException("Failed to create user");
        }

        _logger.LogInformation("Created user {Email}", dto.Email);

        return _mapper.Map<UserReadDto>(user);
    }

    public async Task Delete(int ID)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"User with ID {ID} not found.");

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            _logger.LogError("Failed to delete user with ID {Id}: {Errors}", ID, result.Errors);
            throw new BadRequestException("Failed to delete user");
        }

        _logger.LogInformation("Deleted user with ID {Id}", ID);
    }

    public async Task UpdateLanguage(int ID, int languageID)
    {
        var user = await _userManager.FindByIdAsync(ID.ToString())
            ?? throw new NotFoundException($"User with ID {ID} not found");

        var languageExists = await _context.Languages.AnyAsync(x => x.ID == languageID);
        if (!languageExists) throw new NotFoundException($"Language with ID {ID} not found");

        user.LanguageID = languageID;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            _logger.LogError("Failed to update language for user {Id}: {Errors}", ID, result.Errors);
            throw new BadRequestException($"Error updating language");
        }

        _logger.LogInformation("Updated language for user {Id} to {LanguageId}", ID, languageID);
    }
    #endregion

    #region Private Methods & Helpers

    #endregion
}
