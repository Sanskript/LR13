using Microsoft.AspNetCore.Mvc;
using Serilog;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // Завдання 2: Використання рівнів логування
        Log.Debug("Це повідомлення рівня Debug.");
        Log.Information("Це інформаційне повідомлення.");
        Log.Warning("Це попередження.");
        Log.Error("Це повідомлення про помилку.");
        Log.Fatal("Це фатальне повідомлення.");
        

        // Завдання 3: Використання шаблонів повідомлень
        var user = new { Name = "Макс", Age = 200 };
        Log.Information("Користувач {Name} увійшов у систему у {Time}", user.Name, DateTime.Now);
        Log.Information("Дані користувача: {@User}", user);


        return View();


    }
}
