using System;

namespace ДомашнееЗадание_2
{
    //DRY
    public enum LogLevel { Info, Warning, Error }
    public class Logger
    {
        public void Log(string message, LogLevel level)
        {
            Console.WriteLine($"{level.ToString().ToUpper()}: {message}");
        }
    }
    public static class AppConfig
    {
        public static string ConnectionString =>
            "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
    }
    public class DatabaseService
    {
        public void Connect()
        {
            Console.WriteLine($"Подключение к БД: {AppConfig.ConnectionString}");
        }
    }
    public class LoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine($"Сохранение лога '{message}' в БД: {AppConfig.ConnectionString}");
        }
    }
    //KISS
    public class NumberProcessor
    {
        public void ProcessNumbers(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return;
            foreach (var number in numbers)
            {
                if (number > 0)
                    Console.WriteLine(number);
            }
        }
    }
    public class PositivePrinter
    {
        public void PrintPositiveNumbers(int[] numbers)
        {
            foreach (var number in numbers)
            {
                if (number > 0)
                    Console.WriteLine(number);
            }
        }
    }
    public class Divider
    {
        public int Divide(int a, int b)
        {
            if (b == 0)
                Console.WriteLine("Ошибка: деление на ноль, возвращаемое значение 0"); 
                return 0;
            return a / b;
        }
    }
    //YAGNI
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class FileReader
    {
        public string ReadFile(string filePath)
        {
            return $"Содержимое файла {filePath}";
        }
    }
    public class ReportGenerator
    {
        public void GeneratePdfReport()
        {
            Console.WriteLine("Генерация PDF отчета...");
        }
    }
    // === Program ===
    class Program
    {
        static void Main()
        {
            Console.WriteLine("DRY");
            var logger = new Logger();
            logger.Log("Это инфо", LogLevel.Info);
            logger.Log("Это предупреждение", LogLevel.Warning);
            logger.Log("Это ошибка", LogLevel.Error);

            var dbService = new DatabaseService();
            dbService.Connect();

            var logService = new LoggingService();
            logService.Log("Тестовый лог");

            Console.WriteLine("\nKISS");
            var processor = new NumberProcessor();
            processor.ProcessNumbers(new[] { -2, 0, 3, 7 });

            var printer = new PositivePrinter();
            printer.PrintPositiveNumbers(new[] { -5, 10, 20 });

            var divider = new Divider();
            Console.WriteLine($"10 / 2 = {divider.Divide(10, 2)}");
            Console.WriteLine($"10 / 0 = {divider.Divide(10, 0)}");

            Console.WriteLine("\nYAGNI");
            var user = new User { Name = "Анна", Email = "anna@example.com" };
            Console.WriteLine($"Пользователь: {user.Name}, {user.Email}");

            var reader = new FileReader();
            Console.WriteLine(reader.ReadFile("data.txt"));

            var report = new ReportGenerator();
            report.GeneratePdfReport();
        }
    }
}