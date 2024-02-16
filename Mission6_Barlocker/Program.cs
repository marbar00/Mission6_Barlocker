using Microsoft.EntityFrameworkCore;
using Mission6_Barlocker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieInputContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:MovieInputConnection"]);
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
