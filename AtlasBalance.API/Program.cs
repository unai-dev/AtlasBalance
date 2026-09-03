using AtlasBalance.Infrastructure;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string cn = builder.Configuration.GetConnectionString("MariaDB")!;
builder.Services.AddDbContext<AtlasDbContext>(options =>
{
    options.UseMySql(cn, ServerVersion.AutoDetect(cn));
});


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
