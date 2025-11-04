using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_8._1
{
    public interface IReport
    {
        string Generate();
    }
    public class SalesReport : IReport
    {
        private List<Sale> sales;
        public SalesReport()
        {
            sales = new List<Sale>
            {
                new Sale { Id = 1, Date = new DateTime(2024, 10, 15), Product = "Ноутбук", Amount = 200000, Customer = "Иванов И.И." },
                new Sale { Id = 2, Date = new DateTime(2024, 10, 20), Product = "Смартфон", Amount = 60000, Customer = "Петров П.П." },
                new Sale { Id = 3, Date = new DateTime(2024, 10, 25), Product = "Планшет", Amount = 70000, Customer = "Сидоров С.С." },
                new Sale { Id = 4, Date = new DateTime(2024, 11, 5), Product = "Наушники", Amount = 8000, Customer = "Козлов К.К." },
                new Sale { Id = 5, Date = new DateTime(2024, 11, 10), Product = "Клавиатура", Amount = 15000, Customer = "Новиков Н.Н." }
            };
        }
        public List<Sale> GetSales() => new List<Sale>(sales);
        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Отчет по продажам");
            sb.AppendLine();
            foreach (var sale in sales)
            {
                sb.AppendLine(sale.ToString());
            }
            sb.AppendLine();
            sb.AppendLine($"Общее количество продаж: {sales.Count}");
            sb.AppendLine($"Общая сумма: {sales.Sum(s => s.Amount)}");
            return sb.ToString();
        }
    }
    public class UserReport : IReport
    {
        private List<User> users;
        public UserReport()
        {
            users = new List<User>
            {
                new User { Id = 1, Name = "Иван Иванов", Email = "ivanov@gmail.com", RegistrationDate = new DateTime(2024, 1, 15), Status = "Активный" },
                new User { Id = 2, Name = "Мария Кузнецова", Email = "kuznetsova@mail.ru", RegistrationDate = new DateTime(2024, 3, 20), Status = "Активный" },
                new User { Id = 3, Name = "Сергей Сергеев", Email = "serj@gmail.com", RegistrationDate = new DateTime(2024, 5, 10), Status = "Неактивный" },
                new User { Id = 4, Name = "Игорь Соколов", Email = "sokol@gmail.com", RegistrationDate = new DateTime(2024, 7, 5), Status = "Активный" },
                new User { Id = 5, Name = "Петр Петренко", Email = "petrpetr@mail.ru", RegistrationDate = new DateTime(2024, 9, 15), Status = "Заблокирован" }
            };
        }
        public List<User> GetUsers() => new List<User>(users);
        public string Generate()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Отчет по пользователям");
            sb.AppendLine();
            foreach (var user in users)
            {
                sb.AppendLine(user.ToString());
            }
            sb.AppendLine();
            sb.AppendLine($"Общее количество пользователей: {users.Count}");
            return sb.ToString();
        }
    }
}
