using System.Text;

using AtlasBalance.API.Middlewares;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Application.MappingProfiles;
using AtlasBalance.Application.Services;
using AtlasBalance.Domain.Models;
using AtlasBalance.Infrastructure;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          SERVICES
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
var builder = WebApplication.CreateBuilder(args);

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          CONTROLLERS
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
builder.Services.AddControllers();

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          DB
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
string cn = builder.Configuration.GetConnectionString("MariaDB")!;
builder.Services.AddDbContext<AtlasDbContext>(options =>
{
    options.UseMySql(cn, ServerVersion.AutoDetect(cn));
});

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          AUTO MAPPER
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<CategoryProfile>();
    cfg.AddProfile<CurrencyProfile>();
    cfg.AddProfile<PaymentMethodProfile>();
    cfg.AddProfile<AccountProfile>();
    cfg.AddProfile<ExpenseProfile>();
});

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          DI
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
//auth services
builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();
builder.Services.AddScoped<IAuthService, AuthService>();

//app services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          AUTH CONFIG
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AtlasDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.MapInboundClaims = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT_SECRET"]!)),
        ClockSkew = TimeSpan.Zero
    };
});

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          CORS
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cfg => cfg.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 */

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          APP
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
var app = builder.Build();

/**
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 |                                          MIDDLEWARES
 | * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 */
app.UseHttpsRedirection();
app.UseMiddleware<CatchExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.Run();
