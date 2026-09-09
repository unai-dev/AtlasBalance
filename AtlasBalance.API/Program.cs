using AtlasBalance.API.Middlewares;
using AtlasBalance.Application.Interfaces;
using AtlasBalance.Application.MappingProfiles;
using AtlasBalance.Application.Services;
using AtlasBalance.Infrastructure;

using Microsoft.EntityFrameworkCore;

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
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();

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
