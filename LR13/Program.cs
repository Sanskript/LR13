using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// ������������ Serilog
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .Enrich.WithExceptionDetails() // �������� 5: ������������ Serilog.Exceptions  ��� ���������� ���� �������� �������.
    .WriteTo.Console() // �������� 1: ��������� � �������
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // �������� 1: ��������� � ����
    .CreateLogger();

builder.Host.UseSerilog(); // �������� 4: ���������� Serilog � ASP.NET Core

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
