using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork_7._2
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Тестирование генерации отчётов ===");

            Console.WriteLine("\n--- PDF Report ---");
            var pdf = new PdfReport();
            pdf.GenerateReport();

            Console.WriteLine("\n--- Excel Report ---");
            var excel = new ExcelReport();
            excel.GenerateReport();

            Console.WriteLine("\n--- HTML Report ---");
            var html = new HtmlReport();
            html.GenerateReport();

            Console.WriteLine("\n--- CSV Report (новый тип) ---");
            var csv = new CsvReport();
            csv.GenerateReport();

            Console.WriteLine("\nВсе тесты завершены. Лог записан в файл report_generation_log.txt");
        }
    }
}
