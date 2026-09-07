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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
