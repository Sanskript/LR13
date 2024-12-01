using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Налаштування Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.WithExceptionDetails() // Завдання 5: Використання Serilog.Exceptions  для збагачення логів деталями винятків.
    .WriteTo.Console() // Завдання 1: Логування в консоль
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Завдання 1: Логування у файл
    .CreateLogger();

builder.Host.UseSerilog(); // Завдання 4: Інтеграція Serilog з ASP.NET Core

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
