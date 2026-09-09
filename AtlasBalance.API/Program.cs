using AtlasBalance.API.Middlewares;
using AtlasBalance.Application.MappingProfiles;
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
