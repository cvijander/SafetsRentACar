using Microsoft.EntityFrameworkCore;
using SafetsRentACar;
using SafetsRentACar.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SafetsRentalContext>(
    op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).
    EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
