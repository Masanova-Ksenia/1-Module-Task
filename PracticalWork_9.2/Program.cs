using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalWork_9._2
{
    class Program
    {
        static void Main()
        {
            var e1 = new Employee("Иван Иванов", "Менеджер", 300000);
            var e2 = new Employee("Петр Петров", "Бухгалтер", 250000);
            var e3 = new Employee("Павел Павлов", "Разработчик", 400000);
            var e4 = new Contractor("Валерия Валерьева", "Фрилансер", 180000);

            var devDept = new Department("IT отдел");
            var hrDept = new Department("HR отдел");
            var mainDept = new Department("Головной департамент");

            devDept.Add(e3);
            devDept.Add(e4);

            hrDept.Add(e2);

            mainDept.Add(e1);
            mainDept.Add(devDept);
            mainDept.Add(hrDept);

            Console.WriteLine("\nСтруктура организации");
            mainDept.Display();

            Console.WriteLine("\nОбщий бюджет организации");
            Console.WriteLine($"{mainDept.GetBudget()}");

            Console.WriteLine("\nОбщее количество сотрудников");
            Console.WriteLine(mainDept.GetEmployeeCount());

            Console.WriteLine("\nИзменение зарплаты сотрудника");
            e3.SetSalary(450000);
            Console.WriteLine($"Петр Петров теперь получает {e3.GetBudget()}");
            Console.WriteLine($"Новый бюджет отдела IT: {devDept.GetBudget()}");

            Console.WriteLine("\nПоиск сотрудника по имени");
            var found = mainDept.FindEmployee("Павел Павлов");
            if (found != null)
                found.Display();

            Console.WriteLine("\nВсе сотрудники IT отдела и подотделов");
            foreach (var emp in devDept.GetAllEmployees())
                Console.WriteLine($"- {emp.Name}, {emp.Position}");
        }
    }
}
