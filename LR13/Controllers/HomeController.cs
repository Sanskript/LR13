using Microsoft.AspNetCore.Mvc;
using Serilog;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // �������� 2: ������������ ���� ���������
        Log.Debug("�� ����������� ���� Debug.");
        Log.Information("�� ������������ �����������.");
        Log.Warning("�� ������������.");
        Log.Error("�� ����������� ��� �������.");
        Log.Fatal("�� �������� �����������.");
        

        // �������� 3: ������������ ������� ����������
        var user = new { Name = "����", Age = 200 };
        Log.Information("���������� {Name} ������ � ������� � {Time}", user.Name, DateTime.Now);
        Log.Information("��� �����������: {@User}", user);


        return View();


    }
}
